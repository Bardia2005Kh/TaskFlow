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
        

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
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
            var taskItemDto = await taskService.GetByIdService(id);
            if (taskItemDto == null)
            {
                return NotFound();
            }

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

            return Ok(updationResult);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await taskService.DeleteService(id);
            if (result == false)
            {
                return NotFound();
            }

            return Ok("Task deleted!");
        }
    }
}
