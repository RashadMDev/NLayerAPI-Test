using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayerApp.API.DTOs;
using NLayerApp.Core.Entities;
using NLayerApp.DAL.Data;

namespace NLayerApp.API.Controllers
{
      [ApiController]
      [Route("api/[controller]")]
      public class CategoriesController : ControllerBase
      {
            private readonly AppDbContext _context;

            public CategoriesController(AppDbContext context)
            {
                  _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
            {
                  var categories = await _context.Categories.ToListAsync();
                  var categoryDtos = categories.Select(c => new CategoryDto
                  {
                        Id = c.Id,
                        Name = c.Name
                  });
                  return Ok(categoryDtos);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<CategoryDto>> GetById(int id)
            {
                  var category = await _context.Categories.FindAsync(id);
                  if (category == null)
                  {
                        return NotFound();
                  }

                  var categoryDto = new CategoryDto
                  {
                        Id = category.Id,
                        Name = category.Name
                  };
                  return Ok(categoryDto);
            }

            [HttpPost]
            public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createDto)
            {
                  var category = new Category
                  {
                        Name = createDto.Name,
                  };

                  _context.Categories.Add(category);
                  await _context.SaveChangesAsync();

                  var categoryDto = new CategoryDto
                  {
                        Id = category.Id,
                        Name = category.Name
                  };

                  return CreatedAtAction(nameof(GetById), new { id = category.Id }, categoryDto);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, UpdateCategoryDto updateDto)
            {
                  var category = await _context.Categories.FindAsync(id);
                  if (category == null)
                  {
                        return NotFound();
                  }

                  category.Name = updateDto.Name;

                  await _context.SaveChangesAsync();

                  return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                  var category = await _context.Categories.FindAsync(id);
                  if (category == null)
                  {
                        return NotFound();
                  }

                  _context.Categories.Remove(category);
                  await _context.SaveChangesAsync();

                  return NoContent();
            }
      }
}
