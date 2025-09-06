using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.TaskItemDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Application.IServices;
using TaskFlow.Domain.Models;
using static TaskFlow.Domain.Models.TaskItem;

namespace TaskFlow.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper mapper;
        private readonly ITaskRepository taskRepository;

        public TaskService(IMapper mapper, ITaskRepository taskRepository)
        {
            this.mapper = mapper;
            this.taskRepository = taskRepository;
        }
        public async Task<bool> CreateService(AddTaskRequestDto addTaskRequestDto)
        {
            var taskItemDomain = mapper.Map<TaskItem>(addTaskRequestDto);

            var creationResult = await taskRepository.CreateAsync(taskItemDomain);

            return creationResult;
        }

        public async Task<List<TaskItemDto>> GetAllService()
        {
            var tasksDomain = await taskRepository.GetAllAsync();

            var tasksDto = mapper.Map<List<TaskItemDto>>(tasksDomain);

            return tasksDto;
        }

        public async Task<TaskItemDto?> UpdateService(int id, UpdateTaskRequest updateTaskRequest)
        {
            var existingTask = await taskRepository.GetByIdAsync(id);

            if (existingTask == null)
            {
                return null;
            }

            existingTask.Title = updateTaskRequest.Title;
            existingTask.Description = updateTaskRequest.Description;
            existingTask.TaskStatus = updateTaskRequest.TaskStatus;
            existingTask.TaskPriorty = updateTaskRequest.TaskPriorty;
            existingTask.UserId = updateTaskRequest.UserId;
            existingTask.CategoryId = updateTaskRequest.CategoryId;

            var result = await taskRepository.UpdateAsync(existingTask);
            if (!result)
            {
                throw new Exception("Update faild");
            }

            var taskItemDto = mapper.Map<TaskItemDto>(existingTask);

            return taskItemDto;
        }

    
    }
}
