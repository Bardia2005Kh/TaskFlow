using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.CommentDTOs;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.IServices
{
    public interface ICommentService
    {
        Task<CommentDto?> CreateService(AddCommentRequestDto addCommentRequestDto);
        Task<List<CommentDto>> GetAllService();
        Task<CommentDto?> GetByIdService(int id);
        Task<bool> UpdateService(int id, UpdateCommentRequestDto updateCommentRequestDto);
        Task<bool> DeleteService(int id);
    }
}
