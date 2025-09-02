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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TaskFlowDbContext dbContext;

        public CategoryRepository(TaskFlowDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> CreateAsync(Category category)
        {
            await dbContext.categories.AddAsync(category);
            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
