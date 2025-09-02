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

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var taskItemDomain = await taskRepository.GetByIdAsync(id);
            if (taskItemDomain == null)
            {
                return NotFound();
            }

            var taskItemDto = mapper.Map<TaskItemDto>(taskItemDomain);

            return Ok(taskItemDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taskItemDomain = await taskRepository.GetAllAsync();

            var taskItemDto = mapper.Map<List<TaskItemDto>>(taskItemDomain);

            return Ok(taskItemDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskRequest updateTaskRequest)
        {
            var taskItemDomain = mapper.Map<TaskItem>(updateTaskRequest);
            taskItemDomain = await taskRepository.UpdateAsync(id, taskItemDomain);
            if (taskItemDomain == null)
            {
                return NotFound();
            }

            var taskItemDto = mapper.Map<TaskItemDto>(taskItemDomain);

            return Ok(taskItemDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await taskRepository.DeleteAsync(id);
            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
