﻿using MealOrdering.Application.Features.Users.DTOs;
using MealOrdering.Application.Repositories.Users;
using MealOrdering.Application.Services.PersistenceServices;
using MealOrdering.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MealOrdering.Persistence.Services
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserManager(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<bool> CreateUser(CreateUserDTO createUserDTO)
        {
            await _userRepository.AddAsync(new() { FirstName = createUserDTO.FirstName, LastName = createUserDTO.LastName, EmailAddress = createUserDTO.EmailAddress });
            return await _userRepository.SaveAsync() > 0;
        }

        public async Task<bool> DeleteUserById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id, true);
            if (user == null)
                throw new Exception("User Not Found");

            _userRepository.Remove(user);
            return await _userRepository.SaveAsync() > 0;
        }

        public async Task<List<ListUserDTO>> GetAllUsers()
        {
            List<ListUserDTO> users = await _userRepository.Table.Select(u => new ListUserDTO
            {
                Id = u.Id.ToString(),
                FullName = $"{u.FirstName} {u.LastName}",
                Email = u.EmailAddress,
                CreatedAt = u.CreatedDate,
                Status = u.IsActive
            }).ToListAsync();

            return users;
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
                return new()
                {
                    Id = user.Id.ToString(),
                    FullName = $"{user.FirstName} {user.LastName}",
                    Email = user.EmailAddress,
                    Status = user.IsActive,
                    CreatedAt = user.CreatedDate
                };
            else
                throw new Exception("User Not Found");

        }

        public async Task<UserLoginResponseDTO> Login(UserLoginRequestDTO userLoginRequestDTO)
        {
            var encryptedPassword = PasswordEncrypterHelper.Encrypt(userLoginRequestDTO.Password);

            var user = await _userRepository.Table.FirstOrDefaultAsync(u => u.EmailAddress == userLoginRequestDTO.Email && u.Password == encryptedPassword);
            if (user == null)
                throw new Exception("Kullanıcı Bulunamadı Bilgiler Yanlış");
            if (!user.IsActive)
                throw new Exception("Kullanıcı Pasif durumdadır");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(_configuration["JwtExpiryInDays"].ToString()));

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,userLoginRequestDTO.Email),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}")
            };
            var token = new JwtSecurityToken(issuer: _configuration["JwtIssuer"], audience: _configuration["JwtAudience"], claims: claims, expires: expiry, signingCredentials: credentials);
            string createdToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new() 
            { 
                ApiToken = createdToken,
                User = new() 
                { 
                    FullName = $"{user.FirstName} {user.LastName}",
                    Email = user.EmailAddress,
                    Status = user.IsActive,
                    CreatedAt = user.CreatedDate,
                    Id = user.Id.ToString()
                } 
            };
        }

        public async Task<bool> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var user = await _userRepository.GetByIdAsync(updateUserDTO.Id, true);

            if (user == null)
                throw new Exception("User Not Found");

            return _userRepository.Update(user);
        }
    }
}
