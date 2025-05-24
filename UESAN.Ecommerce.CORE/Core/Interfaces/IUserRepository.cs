using UESAN.Ecommerce.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateUser(User user);
        Task DeleteUser(int id);
        Task DeleteUserAsync(int id);
        IEnumerable<User> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> UpdateUser(User user);
    }
}