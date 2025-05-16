using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.CORE.Core.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<FavoriteDetailDTO>> GetAllFavoritesAsync()
        {
            var favorites = await _favoriteRepository.GetAllFavoritesAsync();
            var result = new List<FavoriteDetailDTO>();
            foreach (var f in favorites)
            {
                result.Add(new FavoriteDetailDTO
                {
                    Id = f.Id,
                    CreatedAt = f.CreatedAt,
                    Product = f.Product == null ? null : new FavoriteProductDTO
                    {
                        Id = f.Product.Id,
                        Description = f.Product.Description,
                        ImageUrl = f.Product.ImageUrl,
                        Price = f.Product.Price,
                        Stock = f.Product.Stock,
                        Discount = f.Product.Discount,
                        CategoryId = f.Product.CategoryId
                    },
                    User = f.User == null ? null : new FavoriteUserDTO
                    {
                        Id = f.User.Id,
                        FirstName = f.User.FirstName,
                        LastName = f.User.LastName,
                        Email = f.User.Email
                    }
                });
            }
            return result;
        }

        public async Task<FavoriteDetailDTO> GetFavoriteByIdAsync(int id)
        {
            var f = await _favoriteRepository.GetFavoriteByIdAsync(id);
            if (f == null) return null;
            return new FavoriteDetailDTO
            {
                Id = f.Id,
                CreatedAt = f.CreatedAt,
                Product = f.Product == null ? null : new FavoriteProductDTO
                {
                    Id = f.Product.Id,
                    Description = f.Product.Description,
                    ImageUrl = f.Product.ImageUrl,
                    Price = f.Product.Price,
                    Stock = f.Product.Stock,
                    Discount = f.Product.Discount,
                    CategoryId = f.Product.CategoryId
                },
                User = f.User == null ? null : new FavoriteUserDTO
                {
                    Id = f.User.Id,
                    FirstName = f.User.FirstName,
                    LastName = f.User.LastName,
                    Email = f.User.Email
                }
            };
        }

        public async Task<int> CreateFavorite(FavoriteDTO favoriteDto)
        {
            var favorite = new Favorite
            {
                UserId = favoriteDto.UserId,
                ProductId = favoriteDto.ProductId,
                CreatedAt = favoriteDto.CreatedAt ?? System.DateTime.UtcNow
            };
            return await _favoriteRepository.CreateFavorite(favorite);
        }

        public async Task<bool> DeleteFavorite(int id)
        {
            return await _favoriteRepository.DeleteFavorite(id);
        }
    }
}