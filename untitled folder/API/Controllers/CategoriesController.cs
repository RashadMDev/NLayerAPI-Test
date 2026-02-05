using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.DTOs.CategoryDTOs;
using NLayerApp.Core.Entities;
using NLayerApp.Core.Services;
using NLayerApp.DAL.Data;

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
    }
}
