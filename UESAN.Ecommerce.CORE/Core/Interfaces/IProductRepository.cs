using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<int> CreateProduct(Product product);
        Task DeleteProductAsync(int id);
        Task DeleteProduct(int id);
        Task<bool> UpdateProduct(Product product);
    }
}