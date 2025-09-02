using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.IRepository;
using TaskFlow.Domain.Models;
using TaskFlow.Infra.Data;

namespace TaskFlow.Infra.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TaskFlowDbContext dbContext;

        public CommentRepository(TaskFlowDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(Comment comment)
        {
            await dbContext.comments.AddAsync(comment);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingComment = await dbContext.comments.FirstOrDefaultAsync(c => c.Id == id);
            if (existingComment == null)
            {
                return false;
            }

            dbContext.comments.Remove(existingComment);
            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await dbContext.comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await dbContext.comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateAsync(int id, Comment comment)
        {
            var existingComment = await dbContext.comments.FirstOrDefaultAsync(c => c.Id == id);
            if (existingComment == null)
            {
                return false;
            }

            existingComment.Content = comment.Content;
            existingComment.TaskItemId = comment.TaskItemId;
            existingComment.UserId = comment.UserId;

            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
