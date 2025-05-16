using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly StoreDbContext _context;

        public FavoriteRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorite>> GetAllFavoritesAsync()
        {
            return await _context.Favorite.ToListAsync();
        }

        public async Task<Favorite> GetFavoriteByIdAsync(int id)
        {
            return await _context.Favorite.FindAsync(id);
        }

        public async Task<int> CreateFavorite(Favorite favorite)
        {
            await _context.Favorite.AddAsync(favorite);
            await _context.SaveChangesAsync();
            return favorite.Id;
        }

        public async Task<bool> DeleteFavorite(int id)
        {
            var favorite = await _context.Favorite.FindAsync(id);
            if (favorite == null) return false;
            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}