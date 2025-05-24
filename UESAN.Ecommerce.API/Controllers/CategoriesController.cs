using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Core.Services;


namespace UESAN.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //private readonly ICategoryRepository _categoryRepository;

        //public CategoriesController(ICategoryRepository categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}

        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            if (categoryCreateDTO == null)
            {
                return BadRequest("Category is null");
            }

            var newCategoryId =  await _categoryService.CreateCategory(categoryCreateDTO);
            //return
            return Ok(newCategoryId);
        }
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryListDTO categoryListDTO)
        {
            if (categoryListDTO == null || id != categoryListDTO.Id)
            {
                return BadRequest("Category is null or ID mismatch");
            }
            var updatedCategory = await _categoryService.UpdateCategory(categoryListDTO);
            if (!updatedCategory)
            {
                return NotFound();
            }
            return Ok(updatedCategory);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
            
            return NoContent();
        }
    }
}
