using MealOrdering.Application.Features.Orders.DTOs;
using MealOrdering.Application.Services.PersistenceServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Blazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
            => Ok(await _orderService.GetAllOrders());
        [HttpGet]
        public async Task<IActionResult> GetByOrderId(string id)
            => Ok(await _orderService.GetOrderById(id));
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO createUserDTO)
            => Ok(await _orderService.CreateOrder(createUserDTO));
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDTO updateUserDTO)
            => Ok(await _orderService.UpdateOrder(updateUserDTO));
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderById(string id)
            => Ok(await _orderService.DeleteOrderById(id));
    }
}
