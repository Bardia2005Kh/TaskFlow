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
        public DbSet<TaskItem> taskItems { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasOne(i => i.User)
                .WithMany(i => i.Tasks)
                .HasForeignKey(i => i.UserId)
                .IsRequired();

            modelBuilder.Entity<TaskItem>()
                .HasOne(i => i.Category)
                .WithMany(i => i.TaskItems)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(i => i.User)
                .WithMany(i => i.Comments)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasOne(i => i.User)
                .WithMany(i => i.Categories)
                .HasForeignKey(i => i.UserId)
                .IsRequired();


        }
    }
}
