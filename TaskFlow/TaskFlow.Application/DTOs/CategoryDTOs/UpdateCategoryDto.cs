using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.DTOs.CategoryDTOs
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; }
        public string Color { get; set; } = "#007BFF";

        // Foreign Keys 
        public int UserId { get; set; }
    }
}