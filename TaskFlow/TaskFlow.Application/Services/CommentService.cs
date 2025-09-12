using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.CommentDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Application.IServices;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        public async Task<CommentDto?> CreateService(AddCommentRequestDto addCommentRequestDto)
        {
            var commentDomain = mapper.Map<Comment>(addCommentRequestDto);
            var creationResult = await commentRepository.CreateAsync(commentDomain);
            if (creationResult == false)
            {
                throw new Exception("Creation faild!");
            }

            var commentDto = mapper.Map<CommentDto>(addCommentRequestDto);

            return commentDto;
        }
    }
}
