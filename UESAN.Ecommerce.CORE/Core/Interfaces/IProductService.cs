using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<int> CreateProduct(ProductDTO productDto);
        Task<bool> UpdateProduct(ProductDTO productDto);
        Task DeleteProduct(int id);
    }
}