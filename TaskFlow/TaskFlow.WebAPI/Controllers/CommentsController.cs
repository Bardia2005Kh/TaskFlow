using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.CommentDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Application.IServices;
using TaskFlow.Domain.Models;

namespace TaskFlow.WebAPI.Controllers
{
    // Controller for managing comment-related API endpoints
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        // Constructor injects repository and mapper dependencies
        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // Create a new comment
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCommentRequestDto addCommentRequestDto)
        {
            // Save comment to database
            var creationResult = await commentService.CreateService(addCommentRequestDto);
            if (creationResult == null)
            {
                return BadRequest("Commention faild!");
            }

            return Ok();
        }

        // Get all comments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commentsDto = await commentService.GetAllService();

            return Ok(commentsDto);
        }

        // Get a comment by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Retrieve comment by ID
            var commentDto = await commentService.GetByIdService(id);
            if (commentDto == null)
            {
                // Return 404 if not found
                return NotFound();
            }

            return Ok(commentDto);
        }

        // Update an existing comment
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateCommentRequestDto)
        {
            var updateResult = await commentService.UpdateService(id, updateCommentRequestDto);
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
            var DeleteResult = await commentService.DeleteService(id);
            if (DeleteResult == false)
            {
                // Return 404 if delete failed
                return NotFound();
            }

            return Ok("Comment's deleted!");
        }
    }
}
