using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.IRepository
{
    public interface ICommentRepository
    {
        Task<bool> CreateAsync(Comment comment);
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Comment comment);
        Task<bool> DeleteAsync(int id);
    }
}
