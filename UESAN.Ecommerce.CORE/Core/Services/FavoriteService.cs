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

        public async Task<IEnumerable<FavoriteDTO>> GetAllFavoritesAsync()
        {
            var favorites = await _favoriteRepository.GetAllFavoritesAsync();
            var result = new List<FavoriteDTO>();
            foreach (var f in favorites)
            {
                result.Add(new FavoriteDTO
                {
                    Id = f.Id,
                    UserId = f.UserId,
                    ProductId = f.ProductId,
                    CreatedAt = f.CreatedAt
                });
            }
            return result;
        }

        public async Task<FavoriteDTO> GetFavoriteByIdAsync(int id)
        {
            var f = await _favoriteRepository.GetFavoriteByIdAsync(id);
            if (f == null) return null;
            return new FavoriteDTO
            {
                Id = f.Id,
                UserId = f.UserId,
                ProductId = f.ProductId,
                CreatedAt = f.CreatedAt
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