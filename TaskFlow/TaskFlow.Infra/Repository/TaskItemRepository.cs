using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class TaskItemRepository : ITaskRepository
    {
        private readonly TaskFlowDbContext dbContext;

        public TaskItemRepository(TaskFlowDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<bool> CreateAsync(TaskItem taskItem)
        {
            await dbContext.taskItems.AddAsync(taskItem);
            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingTask = await dbContext.taskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTask == null)
            {
                return false;
            }

            dbContext.taskItems.Remove(existingTask);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<TaskItem>> GetAllAsync()
        {
            return dbContext.taskItems.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await dbContext.taskItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> UpdateAsync(TaskItem taskItem)
        {
            dbContext.taskItems.Update(taskItem);
            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}