﻿using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login(UserLoginRequestDTO userLoginRequestDTO)
        {
            return new()
            {
                Value = await _userService.Login(userLoginRequestDTO)
            };
        }

        [HttpGet]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new() { Value = await _userService.GetUsers() };
        }

        [HttpPost]
        public async Task<ServiceResponse<UserDTO>> CreateUser([FromBody] UserDTO userDTO)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await _userService.CreateUser(userDTO)
            };
        }

        [HttpPut]
        public async Task<ServiceResponse<UserDTO>> UpdateUser([FromBody] UserDTO userDTO)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await _userService.UpdateUser(userDTO)
            };
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<UserDTO>> GetUserById(Guid id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await _userService.GetUserById(id)
            };
        }

    }
}
