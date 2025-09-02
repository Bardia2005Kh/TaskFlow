using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.DTOs.CommentDTOs
{
    public class UpdateCommentRequestDto
    {
        public string Content { get; set; }

        // Foreign Keys
        public int? TaskItemId { get; set; }
        public int UserId { get; set; }
    }
}
