using MealOrdering.Application.Features.Users.DTOs;
using MealOrdering.Application.Features.Users.Queries.GetAll;
using MealOrdering.Application.Services.PersistenceServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Blazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region MediatR
        //private readonly IMediator _mediator;

        //public UsersController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllUser(GetAllUserQueryRequest getAllUserQueryRequest)
        //{
        //    GetAllUserQueryResponse response = await _mediator.Send(getAllUserQueryRequest);
        //    return Ok(response);
        //}
        #endregion
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
            => Ok(await _userService.GetAllUsers());
        [HttpGet]
        public async Task<IActionResult> GetByUserId(string id)
            => Ok(await _userService.GetUserById(id));
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDTO)
            => Ok(await _userService.CreateUser(createUserDTO));
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO updateUserDTO)
            => Ok(await _userService.UpdateUser(updateUserDTO));
        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(string id)
            => Ok(await _userService.DeleteUserById(id));
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestDTO userLoginRequestDTO)
        {
            var response = await _userService.Login(userLoginRequestDTO);
            return Ok(response);
        }
    }
}
