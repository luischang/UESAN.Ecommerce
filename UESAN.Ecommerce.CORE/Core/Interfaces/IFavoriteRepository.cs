using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetAllFavoritesAsync();
        Task<Favorite> GetFavoriteByIdAsync(int id);
        Task<int> CreateFavorite(Favorite favorite);
        Task<bool> DeleteFavorite(int id);
    }
}