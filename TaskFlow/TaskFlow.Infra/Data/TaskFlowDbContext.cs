using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Infra.Data
{
    public class TaskFlowDbContext : DbContext
    {
        public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}
