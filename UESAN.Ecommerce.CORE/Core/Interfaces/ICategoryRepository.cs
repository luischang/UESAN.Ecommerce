using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> CreateCategory(Category category);
        Task DeleteCategory(int id);
        Task DeleteCategoryAsync(int id);
        IEnumerable<Category> GetAllCategories();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategory(Category category);
    }
}