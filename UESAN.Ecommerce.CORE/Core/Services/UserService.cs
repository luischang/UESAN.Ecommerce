using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.CORE.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;

        public UserService(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<IEnumerable<UserListDTO>> GetUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userList = new List<UserListDTO>();
            foreach (var user in users)
            {
                userList.Add(new UserListDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                });
            }
            return userList;
        }

        public async Task<UserListDTO> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return null;
            return new UserListDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public async Task<int> CreateUser(UserCreateDTO userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Country = userDto.Country,
                Address = userDto.Address,
                Password = userDto.Password,
                Type = userDto.Type,
                IsActive = true
            };
            return await _userRepository.CreateUser(user);
        }

        public async Task<bool> UpdateUser(UserListDTO userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                IsActive = true
            };
            return await _userRepository.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<SignInResponseDTO> SignIn(SignInRequestDTO request)
        {
            var users = await _userRepository.GetAllUsersAsync();
            var user = users.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password && u.IsActive == true);
            if (user == null)
                return null;
            var token = _jwtService.GenerateJWToken(user);
            return new SignInResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Country = user.Country,
                Address = user.Address,
                Type = user.Type,
                Token = token
            };
        }
    }
}
