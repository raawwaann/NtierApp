using Microsoft.AspNetCore.Mvc;
using NtierApp.Services;

namespace NtierApp.Api.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;

        public CategoriesController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var Categories= await _CategoryService.GetAllAsync();
            return Ok(Categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var Category = await _CategoryService.GetByIdAsync(id);
            if (Category == null) return NotFound();
            return Ok(Category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto CategoryDto)
        {
            await _CategoryService.AddAsync(CategoryDto);
            return CreatedAtAction(nameof(GetById), new { id = CategoryDto.Id }, CategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDto CategoryDto)
        {
            if (id != CategoryDto.Id) return BadRequest();

            await _CategoryService.UpdateAsync(CategoryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _CategoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

