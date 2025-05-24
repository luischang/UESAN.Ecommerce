using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _context;

        public UserRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.User.Where(x => x.IsActive == true).ToList();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.User.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.User.Where(x => x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> CreateUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                user.IsActive = false;
                _context.User.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            var existingUser = await _context.User.FindAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Country = user.Country;
                existingUser.Address = user.Address;
                existingUser.Password = user.Password;
                existingUser.Type = user.Type;
                existingUser.IsActive = user.IsActive;
                _context.User.Update(existingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
