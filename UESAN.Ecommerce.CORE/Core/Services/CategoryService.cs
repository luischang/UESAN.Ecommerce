using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.CORE.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {

            var categories = await _categoryRepository.GetAllCategoriesAsync();

            // Map the categories to DTOs with foreach
            var categoryList = new List<CategoryListDTO>();
            foreach (var category in categories)
            {
                var categoryDto = new CategoryListDTO
                {
                    Id = category.Id,
                    Description = category.Description
                };
                categoryList.Add(categoryDto);
            }
            return categoryList;
            //return categories.Select(c => new CategoryListDTO
            //{
            //    Id = c.Id,               
            //    Description = c.Description                
            //});
        }

        public async Task<CategoryListDTO> GetCategoryById(int id)
        {

            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            return new CategoryListDTO
            {
                Id = category.Id,
                Description = category.Description
            };
        }
        public async Task<int> CreateCategory(CategoryCreateDTO categoryDto)
        {
            var category = new Category
            {
                Description = categoryDto.Description,
                IsActive = true
            };

            var id = await _categoryRepository.CreateCategory(category);
            return id;
        }

        public async Task<bool> UpdateCategory(CategoryListDTO categoryDto)
        {
            var category = new Category()
            {
                Id = categoryDto.Id,
                Description = categoryDto.Description,
                IsActive = true
            };

            var result = await _categoryRepository.UpdateCategory(category);

            return result;

        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);

        }
    }
}
