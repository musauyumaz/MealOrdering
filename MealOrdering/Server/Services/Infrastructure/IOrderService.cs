using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Infrastructure
{
    public interface IOrderService
    {
        public Task<OrderDTO> CreateOrderAsync(OrderDTO orderDTO);

        public Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDTO);

        public Task DeleteOrderAsync(Guid orderId);

        public Task<List<OrderDTO>> GetOrdersAsync(DateTime orderDate);

        public Task<OrderDTO> GetOrderByIdAsync(Guid id);



        public Task<OrderItemDTO> CreateOrderItemAsync(OrderItemDTO orderItemDTO);

        public Task<OrderItemDTO> UpdateOrderItemAsync(OrderItemDTO orderItemDTO);

        public Task<List<OrderItemDTO>> GetOrderItemsAsync(Guid orderId);

        public Task<OrderItemDTO> GetOrderItemsByIdAsync(Guid id);

        public Task DeleteOrderItemAsync(Guid orderItemId);
    }
}
