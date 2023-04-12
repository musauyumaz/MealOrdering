using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Server.Services.Services;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #region Order Methods

        [HttpGet("{Id}")]
        public async Task<ServiceResponse<OrderDTO>> GetOrderById(Guid id)
        {
            return new ServiceResponse<OrderDTO>()
            {
                Value = await _orderService.GetOrderByIdAsync(id)
            };
        }

        [HttpGet]
        public async Task<ServiceResponse<List<OrderDTO>>> GetOrdersByDate(DateTime orderDate)
        {
            return new ServiceResponse<List<OrderDTO>>()
            {
                Value = await _orderService.GetOrdersAsync(orderDate)
            };
        }

        [HttpGet]
        public async Task<ServiceResponse<List<OrderDTO>>> GetTodaysOrder()
        {
            return new ServiceResponse<List<OrderDTO>>()
            {
                Value = await _orderService.GetOrdersAsync(DateTime.Now)
            };
        }

        [HttpPost]
        public async Task<ServiceResponse<OrderDTO>> CreateOrder(OrderDTO orderDTO)
        {
            return new ServiceResponse<OrderDTO>()
            {
                Value = await _orderService.CreateOrderAsync(orderDTO)
            };
        }

        [HttpPut]
        public async Task<ServiceResponse<OrderDTO>> UpdateOrder(OrderDTO orderDTO)
        {
            return new ServiceResponse<OrderDTO>()
            {
                Value = await _orderService.UpdateOrderAsync(orderDTO)
            };
        }

        [HttpDelete]
        public async Task<BaseResponse> DeleteOrder([FromBody] Guid orderId)
        {
            await _orderService.DeleteOrderAsync(orderId);
            return new BaseResponse();
        }

        #endregion

        #region OrderItem Methods

        [HttpGet("{id}")]
        public async Task<ServiceResponse<OrderItemDTO>> GetOrderItemsById(Guid id)
        {
            return new ServiceResponse<OrderItemDTO>()
            {
                Value = await _orderService.GetOrderItemsByIdAsync(id)
            };
        }

        [HttpPost]
        public async Task<ServiceResponse<OrderItemDTO>> CreateOrderItem(OrderItemDTO OrderItemDTO)
        {
            return new ServiceResponse<OrderItemDTO>()
            {
                Value = await _orderService.CreateOrderItemAsync(OrderItemDTO)
            };
        }

        [HttpPut]
        public async Task<ServiceResponse<OrderItemDTO>> UpdateOrderItem(OrderItemDTO OrderItemDTO)
        {
            return new ServiceResponse<OrderItemDTO>()
            {
                Value = await _orderService.UpdateOrderItemAsync(OrderItemDTO)
            };
        }

        [HttpDelete]
        public async Task<BaseResponse> DeleteOrderItem([FromBody] Guid orderItemId)
        {
            await _orderService.DeleteOrderItemAsync(orderItemId);
            return new BaseResponse();
        }

        [HttpGet]
        public async Task<ServiceResponse<List<OrderItemDTO>>> GetOrderItems(Guid orderId)
        {
            return new ServiceResponse<List<OrderItemDTO>>()
            {
                Value = await _orderService.GetOrderItemsAsync(orderId)
            };
        }

        #endregion

    }
}
