using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;

        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }
        // Get all categories
        public IEnumerable<Category> GetAllCategories()
        {
            //var context = new StoreDbContext();
            var categories = _context
                            .Category
                            .Where(x => x.IsActive == true)
                            .ToList();
            return categories;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Category
                            .Where(x => x.IsActive == true)
                            .ToListAsync();
        }

        // Get category by id async
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _context
                            .Category
                            .Where(x => x.IsActive == true && x.Id == id)
                            .FirstOrDefaultAsync();
            return category;
        }

        //Create category (Asincrono)
        public async Task<int> CreateCategory(Category category)
        {

            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        //Delete category (soft delete)
        public async Task DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                category.IsActive = false;
                _context.Category.Update(category);
                await _context.SaveChangesAsync();
            }
        }

        //Update category
        public async Task<bool> UpdateCategory(Category category)
        {
            bool result = false;
            var existingCategory = await _context.Category.FindAsync(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Description = category.Description;
                _context.Category.Update(existingCategory);
                await _context.SaveChangesAsync();
                result = true;
            }
            return result;
        }

    }
}
