using UESAN.Ecommerce.CORE.Core.DTOs;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CreateCategory(CategoryCreateDTO categoryDto);
        Task DeleteCategory(int id);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
        Task<bool> UpdateCategory(CategoryListDTO categoryDto);
    }
}