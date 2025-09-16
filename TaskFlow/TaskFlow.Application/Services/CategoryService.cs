using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.CategoryDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Application.IServices;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateService(AddCategoryDto addCategoryDto)
        {
            var categoryDomain = mapper.Map<Category>(addCategoryDto);
            var creationResult = await categoryRepository.CreateAsync(categoryDomain);
            if (creationResult == false)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteService(int id)
        {
            var existingCategory = await categoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return false;
            }

            var deletionResult = await categoryRepository.DeleteAsync(existingCategory);
            if (deletionResult == false)
            {
                throw new Exception("Failed to delete category.");
            }

            return true;
        }

        public async Task<List<CategoryDto>> GetAllService()
        {
            var categoryDomain = await categoryRepository.GetAllAsync();
            var categoryDto = mapper.Map<List<CategoryDto>>(categoryDomain);

            return categoryDto;
        }

        public async Task<CategoryDto?> GetByIdService(int id)
        {
            var categoryDomain = await categoryRepository.GetByIdAsync(id);
            if (categoryDomain == null)
            {
                return null;
            }
            var categoryDto = mapper.Map<CategoryDto>(categoryDomain);

            return categoryDto;
        }

        public async Task<bool> UpdateService(int id, UpdateCategoryDto updateCategoryDto)
        {
            var existingCategory = await categoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.Name = updateCategoryDto.Name;
            existingCategory.Color = updateCategoryDto.Color;
            existingCategory.UserId = updateCategoryDto.UserId;

            var updateResult = await categoryRepository.UpdateAsync(existingCategory);
            if (updateResult == false)
            {
                throw new Exception("Failed to update category.");
            }
            return true;
        }
    }
}

