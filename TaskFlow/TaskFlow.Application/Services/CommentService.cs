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

        public async Task<bool> DeleteService(int id)
        {
            var existingComment = await commentRepository.GetByIdAsync(id);
            if (existingComment == null)
            {
                return false;
            }

            var DeleteCommentResult = await commentRepository.DeleteAsync(existingComment);
            if (DeleteCommentResult == false)
            {
                throw new Exception("Can not delete this comment");
            }
             return true;
        }

        public async Task<List<CommentDto>> GetAllService()
        {
            var commentsDomain = await commentRepository.GetAllAsync();

            var commentsDto = mapper.Map<List<CommentDto>>(commentsDomain);

            return commentsDto;
        }

        public async Task<CommentDto?> GetByIdService(int id)
        {
            var commentDomain = await commentRepository.GetByIdAsync(id);
            if (commentDomain == null)
            {
                return null;
            }

            var commentDto = mapper.Map<CommentDto>(commentDomain);
            return commentDto;
        }

        public async Task<bool> UpdateService(int id, UpdateCommentRequestDto updateCommentRequestDto)
        {
            var existingComment = await commentRepository.GetByIdAsync(id);
            if (existingComment == null)
            {
                return false;
            }

            existingComment.Content = updateCommentRequestDto.Content;
            var updateResult = await commentRepository.UpdateAsync(id, existingComment);
            if (updateResult == false)
            {
                throw new Exception("Update faild!");
            }

            return true;
        }
    }
}
