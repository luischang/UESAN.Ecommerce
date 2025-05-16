using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Product.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Product.Where(x => x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> CreateProduct(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                product.IsActive = false;
                _context.Product.Update(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var existingProduct = await _context.Product.FindAsync(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Description = product.Description;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.Stock = product.Stock;
                existingProduct.Price = product.Price;
                existingProduct.Discount = product.Discount;
                existingProduct.CategoryId = product.CategoryId;
                _context.Product.Update(existingProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
