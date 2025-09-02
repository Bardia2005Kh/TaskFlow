using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.IRepository
{
    public interface ITaskRepository
    {
        Task<bool> CreateAsync(TaskItem taskItem);
        Task<TaskItem?> GetByIdAsync(int id);
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> UpdateAsync(int id, TaskItem taskItem);
        Task<bool> DeleteAsync(int id);
    }
}
