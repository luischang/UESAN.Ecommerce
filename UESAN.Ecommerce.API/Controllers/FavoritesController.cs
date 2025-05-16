using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFavorites()
        {
            var favorites = await _favoriteService.GetAllFavoritesAsync();
            return Ok(favorites);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavoriteById(int id)
        {
            var favorite = await _favoriteService.GetFavoriteByIdAsync(id);
            if (favorite == null)
                return NotFound();
            return Ok(favorite);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFavorite([FromBody] FavoriteDTO favoriteDto)
        {
            if (favoriteDto == null)
                return BadRequest("Favorite is null");
            var newFavoriteId = await _favoriteService.CreateFavorite(favoriteDto);
            return Ok(newFavoriteId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var deleted = await _favoriteService.DeleteFavorite(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
