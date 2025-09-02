using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.DTOs.CommentDTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public int? TaskItemId { get; set; }
        public int UserId { get; set; }

        // Navigation
        public TaskItem? TaskItem { get; set; }
        public User User { get; set; }
    }
}
