using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Shared.DTO;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getusers")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new() { ValueModel = await _userService.GetUsers() };
        }
    }
}
