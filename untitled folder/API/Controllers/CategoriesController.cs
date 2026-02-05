using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.DTOs.CategoryDTOs;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
    }
}