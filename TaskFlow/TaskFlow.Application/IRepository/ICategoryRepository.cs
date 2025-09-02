using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.IRepository
{
    public interface ICategoryRepository
    {
        Task<bool> CreateAsync(Category category);
    }
}
