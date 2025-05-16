using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<IEnumerable<FavoriteDTO>> GetAllFavoritesAsync();
        Task<FavoriteDTO> GetFavoriteByIdAsync(int id);
        Task<int> CreateFavorite(FavoriteDTO favoriteDto);
        Task<bool> DeleteFavorite(int id);
    }
}