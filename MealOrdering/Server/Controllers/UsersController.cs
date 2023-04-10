using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet()]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new() {Value = await _userService.GetUsers()};
        }

    }
}
