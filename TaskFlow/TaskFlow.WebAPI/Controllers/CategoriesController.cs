using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.CategoryDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Application.IServices;
using TaskFlow.Domain.Models;

namespace TaskFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCategoryDto addCategoryDto)
        {
            var creationResult = await categoryService.CreateService(addCategoryDto);
            if (creationResult == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categoryDto = await categoryService.GetAllService();

            return Ok(categoryDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var categoryDto = await categoryService.GetByIdService(id);
            if (categoryDto == null)
            {
                return NotFound("Cant find your category :/");
            }

            return Ok(categoryDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var updateResult = await categoryService.UpdateService(id, updateCategoryDto);
            if (updateResult == false)
            {
                return NotFound("Cant find your category :/");
            }

            return Ok("category successfully updated!");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleteResult = await categoryService.DeleteService(id);
            if (deleteResult == false)
            {
                return NotFound();
            }

            return Ok("category successfully deleted!");
        }
    }
}
