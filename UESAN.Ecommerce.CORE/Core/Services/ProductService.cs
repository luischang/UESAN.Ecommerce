using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.CORE.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Stock = p.Stock,
                Price = p.Price,
                Discount = p.Discount,
                CategoryId = p.CategoryId,
                IsActive = p.IsActive
            });
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var p = await _productRepository.GetProductByIdAsync(id);
            if (p == null) return null;
            return new ProductDTO
            {
                Id = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Stock = p.Stock,
                Price = p.Price,
                Discount = p.Discount,
                CategoryId = p.CategoryId,
                IsActive = p.IsActive
            };
        }

        public async Task<int> CreateProduct(ProductDTO productDto)
        {
            var product = new Product
            {
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                Stock = productDto.Stock,
                Price = productDto.Price,
                Discount = productDto.Discount,
                CategoryId = productDto.CategoryId,
                IsActive = productDto.IsActive
            };
            return await _productRepository.CreateProduct(product);
        }

        public async Task<bool> UpdateProduct(ProductDTO productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                Stock = productDto.Stock,
                Price = productDto.Price,
                Discount = productDto.Discount,
                CategoryId = productDto.CategoryId,
                IsActive = productDto.IsActive
            };
            return await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }
    }
}