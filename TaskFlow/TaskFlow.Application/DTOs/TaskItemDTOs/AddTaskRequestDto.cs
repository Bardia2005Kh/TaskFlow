using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;
using static TaskFlow.Domain.Models.TaskItem;

namespace TaskFlow.Application.DTOs.TaskItemDTOs
{
    public class AddTaskRequestDto
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public Status TaskStatus { get; set; } = Status.Todo;
        public Priorty TaskPriorty { get; set; } = Priorty.Medium;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeadLineDate { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
    }
}
