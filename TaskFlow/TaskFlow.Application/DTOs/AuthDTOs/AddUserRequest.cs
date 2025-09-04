using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskFlow.Domain.Models.User;

namespace TaskFlow.Application.DTOs.AuthDTOs
{
    // DTO for user registration
    public class AddUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; } = Role.User; // Default role is User
    }
}
