using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.DTOs.CategoryDTOs
{
    public class AddCategoryDto
    {
        public string Name { get; set; }
        public string Color { get; set; } = "#007BFF";

        // Foreign Keys 
        public int UserId { get; set; }
    }
}
