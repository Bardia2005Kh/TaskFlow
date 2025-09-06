using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.TaskItemDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Application.IServices;
using TaskFlow.Domain.Models;

namespace TaskFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;

        public TasksController(ITaskService taskService, ITaskRepository taskRepository, IMapper mapper)
        {
            this.taskService = taskService;
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTaskRequestDto addTaskRequestDto)
        {


            var creationResult = await taskService.CreateService(addTaskRequestDto);

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
            var taskItemDto = await taskService.GetAllService();

            return Ok(taskItemDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskRequest updateTaskRequest)
        {
            var updationResult = await taskService.UpdateService(id, updateTaskRequest);
            if (updationResult == null)
            {
                return NotFound();
            }

            var taskItemDto = mapper.Map<TaskItemDto>(updationResult);

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
