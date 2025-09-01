using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; } = "#007BFF";

        // Foreign Keys
        public int UserId { get; set; }

        // Navigation
        public User User { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

    }
}
