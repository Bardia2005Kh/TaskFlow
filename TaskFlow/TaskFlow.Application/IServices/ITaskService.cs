using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.TaskItemDTOs;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.IServices
{
    public interface ITaskService
    {
        Task<bool> CreateService(AddTaskRequestDto addTaskRequestDto);
        Task<List<TaskItemDto>> GetAllService();

        Task<TaskItemDto?> UpdateService(int id, UpdateTaskRequest updateTaskRequest);
    }
}
