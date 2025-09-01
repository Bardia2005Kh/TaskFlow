using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.TaskItemDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Domain.Models;

namespace TaskFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;

        public TasksController(ITaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTaskRequestDto addTaskRequestDto)
        {
            var taskItemDomain = mapper.Map<TaskItem>(addTaskRequestDto);

            var creationResult = await taskRepository.CreateAsync(taskItemDomain);

            if (creationResult == false)
            {
                return BadRequest();
            }

            return Created();
        }
    }
}
