using AutoMapper;
using NLayerApp.Core.DTOs.CategoryDTOs;
using NLayerApp.Core.Entities;
using NLayerApp.Core.Repositories.Generic;
using NLayerApp.Core.Services;
using CategoryEntity = NLayerApp.Core.Entities.Category;

namespace NLayerApp.Business.Services.Category
{

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _repository;
        private readonly IMapper _mapper;


        public CategoryService(IRepository<CategoryEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<CategoryEntity>(dto);
            await _repository.CreateAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<GetCategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            var categoriesDto = _mapper.Map<List<GetCategoryDto>>(categories);
            return categoriesDto;

        }

        public async Task<GetCategoryDto?> GetByIdAsync(int id)
        {

            var category = await _repository.GetByIdAsync(id);
            var categoryDto = _mapper.Map<GetCategoryDto>(category);
            return categoryDto;
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var existingCategory = await _repository.GetByIdAsync(id);
            if (existingCategory is null)
            {
                throw new Exception("Category is not exist");
            }

            _mapper.Map(dto, existingCategory);
            _repository.UpdateAsync(existingCategory);
            await _repository.SaveChangesAsync();
        }
    }
}
