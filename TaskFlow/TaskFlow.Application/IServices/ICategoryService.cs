using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.CategoryDTOs;

namespace TaskFlow.Application.IServices
{
    public interface ICategoryService
    {
        Task<bool> CreateService(AddCategoryDto addCategoryDto);
        Task<List<CategoryDto>> GetAllService();
        Task<CategoryDto?> GetByIdService(int id);
        Task<bool> UpdateService(int id, UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteService(int id);
    }
}
