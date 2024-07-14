using Microsoft.AspNetCore.Mvc;
using NtierApp.Data;
using NtierApp.Services;

namespace NtierApp.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subcategoryService;

        public SubCategoryController(ISubCategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryDto>>> GetAll()
        {
            var subCategories = await _subcategoryService.GetAllAsync();
            return Ok(subCategories);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryDto>> GetById(int id)
        {
            var subCategories = await _subcategoryService.GetByIdAsync(id);
            if (subCategories == null) return NotFound();
            return Ok(subCategories);
        }
        [HttpPost]
        public async Task<IActionResult> Add(SubCategoryDto subcategoryDto)
        {
            await _subcategoryService.AddAsync(subcategoryDto);
            return CreatedAtAction(nameof(GetById), new { id = subcategoryDto.Id }, subcategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubCategoryDto subcategoryDto)
        {
            if (id != subcategoryDto.Id) return BadRequest();

            await _subcategoryService.UpdateAsync(subcategoryDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _subcategoryService.DeleteAsync(id);
            return NoContent();
        }






    }
}
