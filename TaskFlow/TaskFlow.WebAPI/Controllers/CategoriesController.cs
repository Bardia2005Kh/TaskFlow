using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.CategoryDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Domain.Models;

namespace TaskFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCategoryDto addCategoryDto)
        {
            var categoryDomain = mapper.Map<Category>(addCategoryDto);
            var creationResult = await categoryRepository.CreateAsync(categoryDomain);
            if (creationResult == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categoryDomain = await categoryRepository.GetAllAsync();

            var categoryDto = mapper.Map<List<CategoryDto>>(categoryDomain);

            return Ok(categoryDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var categoryDomain = await categoryRepository.GetByIdAsync(id);
            if (categoryDomain == null)
            {
                return NotFound();
            }

            var categoryDto = mapper.Map<CategoryDto>(categoryDomain);
            return Ok(categoryDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var categoryDomain = mapper.Map<Category>(updateCategoryDto);
            var updateResult = await categoryRepository.UpdateAsync(id, categoryDomain);
            if (updateResult == false)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleteResult = await categoryRepository.DeleteAsync(id);
            if (deleteResult == false)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
