using MealOrdering.Application.Features.Orders.DTOs;

namespace MealOrdering.Application.Services.PersistenceServices
{
    public interface IOrderService
    {
        Task<List<ListOrderDTO>> GetAllOrders();
        Task<OrderDTO> GetOrderById(string id);
        Task<bool> CreateOrder(CreateOrderDTO createOrderDTO);
        Task<bool> UpdateOrder(UpdateOrderDTO updateOrderDTO);
        Task<bool> DeleteOrderById(string id);

    }

}
