using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO userCreateDTO)
        {
            if (userCreateDTO == null)
                return BadRequest("User is null");
            var newUserId = await _userService.CreateUser(userCreateDTO);
            return Ok(newUserId);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDTO request)
        {
            if (request == null)
                return BadRequest("Request is null");
            var result = await _userService.SignIn(request);
            if (result == null)
                return Unauthorized();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserListDTO userListDTO)
        {
            if (userListDTO == null || id != userListDTO.Id)
                return BadRequest("User is null or ID mismatch");
            var updated = await _userService.UpdateUser(userListDTO);
            if (!updated)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
