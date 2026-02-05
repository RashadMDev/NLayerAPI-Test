using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.Core.DTOs.CategoryDTOs;

namespace NLayerApp.Core.Services
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto dto);
        void UpdateAsync(int id, UpdateCategoryDto dto);
        void DeleteAsync(int id);
    }
}
