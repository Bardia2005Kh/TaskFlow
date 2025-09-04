using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.AuthDTOs;
using TaskFlow.Application.IRepository;
using TaskFlow.Domain.Models;
using TaskFlow.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
// For password hashing

namespace TaskFlow.Infra.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TaskFlowDbContext dbContext;
        private readonly IConfiguration configuration;

        public AuthRepository(TaskFlowDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        // Login: validate credentials and return JWT token if valid
        public async Task<string?> LoginAsync(LoginRequestDto loginRequest)
        {
            var user = await dbContext.users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
            if (user == null)
                return null;

            // Fix the BCrypt usage issue by replacing the incorrect method call with the correct one.
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash);
            if (!isPasswordValid)
                return null;

            // Generate JWT token
            return CreateToken(user);
        }

        public async Task<User?> AdminRegisterAsync(AddUserRequest addUserRequest)
        {
            // Check if user already exists
            var exists = await dbContext.users.AnyAsync(u => u.Email == addUserRequest.Email);
            if (exists)
                return null;

            // Hash password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(addUserRequest.Password);

            var user = new User
            {
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                Email = addUserRequest.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.Now,
                UserRole = (User.Role)1 // Default to User role
            };

            await dbContext.users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        // Register: create new user with hashed password
        public async Task<User?> RegisterAsync(AddUserRequest addUserRequest)
        {
            // Check if user already exists
            var exists = await dbContext.users.AnyAsync(u => u.Email == addUserRequest.Email);
            if (exists)
                return null;

            // Hash password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(addUserRequest.Password);

            var user = new User
            {
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                Email = addUserRequest.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.Now,
                UserRole = 0 // Default to User role
            };

            await dbContext.users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserRole.ToString()) // Add role claim
            };

            var tokenKey = configuration["AppSettings:Token"];
            if (string.IsNullOrEmpty(tokenKey))
                throw new InvalidOperationException("Token key is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration["AppSettings:Issuer"],
                audience: configuration["AppSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}