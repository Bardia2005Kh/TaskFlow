using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.CategoryDTOs;
using TaskFlow.Application.DTOs.TaskItemDTOs;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.AutoMapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            // TaskItem Mapping Profiles
            CreateMap<TaskItem, AddTaskRequestDto>().ReverseMap();
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
            CreateMap<TaskItem, UpdateTaskRequest>().ReverseMap();

            // Categories Mapping Profiles
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();

        }
    }
}
