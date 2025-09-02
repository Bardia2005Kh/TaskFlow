using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.CommentDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Domain.Models;

namespace TaskFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentsController(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCommentRequestDto addCommentRequestDto)
        {
            var commentDomain = mapper.Map<Comment>(addCommentRequestDto);

            var creationResult = await commentRepository.CreateAsync(commentDomain);
            if (creationResult == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commentsDomain = await commentRepository.GetAllAsync();

            var commentsDto = mapper.Map<List<CommentDto>>(commentsDomain);

            return Ok(commentsDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var commentDomain = await commentRepository.GetByIdAsync(id);
            if (commentDomain == null)
            {
                return NotFound();
            }

            var commentDto = mapper.Map<CommentDto>(commentDomain);

            return Ok(commentDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateCommentRequestDto)
        {
            var commentDomain = mapper.Map<Comment>(updateCommentRequestDto);

        }
    }
}
