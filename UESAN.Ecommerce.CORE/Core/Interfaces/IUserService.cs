using UESAN.Ecommerce.CORE.Core.DTOs;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUser(UserCreateDTO userDto);
        Task DeleteUser(int id);
        Task<IEnumerable<UserListDTO>> GetUsers();
        Task<UserListDTO> GetUserById(int id);
        Task<bool> UpdateUser(UserListDTO userDto);
        Task<SignInResponseDTO> SignIn(SignInRequestDTO request);
    }
}