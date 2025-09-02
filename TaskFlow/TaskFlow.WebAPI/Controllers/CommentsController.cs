using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.CommentDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Domain.Models;

namespace TaskFlow.WebAPI.Controllers
{
    // Controller for managing comment-related API endpoints
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        // Repository for comment data access
        private readonly ICommentRepository commentRepository;
        // Mapper for converting between DTOs and domain models
        private readonly IMapper mapper;

        // Constructor injects repository and mapper dependencies
        public CommentsController(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        // Create a new comment
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCommentRequestDto addCommentRequestDto)
        {
            // Map DTO to domain model
            var commentDomain = mapper.Map<Comment>(addCommentRequestDto);

            // Save comment to database
            var creationResult = await commentRepository.CreateAsync(commentDomain);
            if (creationResult == false)
            {
                // Return error if creation failed
                return BadRequest();
            }

            return Ok();
        }

        // Get all comments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Retrieve all comments from database
            var commentsDomain = await commentRepository.GetAllAsync();

            // Map domain models to DTOs
            var commentsDto = mapper.Map<List<CommentDto>>(commentsDomain);

            return Ok(commentsDto);
        }

        // Get a comment by its ID
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            // Retrieve comment by ID
            var commentDomain = await commentRepository.GetByIdAsync(id);
            if (commentDomain == null)
            {
                // Return 404 if not found
                return NotFound();
            }

            // Map domain model to DTO
            var commentDto = mapper.Map<CommentDto>(commentDomain);

            return Ok(commentDto);
        }

        // Update an existing comment
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateCommentRequestDto)
        {
            // Map DTO to domain model
            var commentDomain = mapper.Map<Comment>(updateCommentRequestDto);

            // Update comment in database
            var updateResult = await commentRepository.UpdateAsync(id, commentDomain);
            if (updateResult == false)
            {
                // Return 404 if update failed
                return NotFound();
            }

            return Ok();
        }

        // Delete a comment by its ID
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            // Delete comment from database
            var DeleteResult = await commentRepository.DeleteAsync(id);
            if (DeleteResult == false)
            {
                // Return 404 if delete failed
                return NotFound();
            }

            return Ok();
        }
    }
}
