using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FuelRoute.Core.DTOs;
using FuelRoute.Core.Interfaces;
using FuelRoute.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FuelRoute.Infrastructure
{
    /// <summary>
    /// Simple authentication service for demo purposes.
    /// Uses IUserRepository to register and validate users.
    /// NOTE: Passwords are stored in plain text here ONLY for assignment demo.
    ///       In a real app, you must hash and salt passwords.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<AuthResultDto> LoginAsync(LoginDto dto)
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Email == dto.Email);

            if (user == null || user.Password != dto.Password)
            {
                return new AuthResultDto
                {
                    Success = false,
                    Error = "Invalid email or password."
                };
            }

            var token = GenerateJwtToken(user);

            return new AuthResultDto
            {
                Success = true,
                Token = token
            };
        }

        public async Task<AuthResultDto> RegisterAsync(UserCreateDto dto)
        {
            var users = await _userRepository.GetAllAsync();
            var existing = users.FirstOrDefault(u => u.Email == dto.Email);

            if (existing != null)
            {
                return new AuthResultDto
                {
                    Success = false,
                    Error = "A user with this email already exists."
                };
            }

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = dto.Password
            };

            await _userRepository.AddAsync(user);

            var token = GenerateJwtToken(user);

            return new AuthResultDto
            {
                Success = true,
                Token = token
            };
        }
        private string GenerateJwtToken(User user)
        {
            var jwtSection = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSection["ExpiresMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
