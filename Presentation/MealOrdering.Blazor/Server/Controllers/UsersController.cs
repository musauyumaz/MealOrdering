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

    }
}
