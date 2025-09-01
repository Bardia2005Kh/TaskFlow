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
    }
}
