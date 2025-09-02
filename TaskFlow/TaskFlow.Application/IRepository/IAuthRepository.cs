using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.AuthDTOs;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.IRepository
{
    public interface IAuthRepository
    {
        Task<User?> RegisterAsync(AddUserRequest addUserRequest);
        Task<string?> LoginAsync(LoginRequestDto loginRequest);
    }
}
