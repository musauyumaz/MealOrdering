using MealOrdering.Application.Features.Orders.DTOs;
using MealOrdering.Application.Repositories.Orders;
using MealOrdering.Application.Services.PersistenceServices;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Persistence.Services
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrder(CreateOrderDTO createOrderDTO)
        {
            await _orderRepository.AddAsync(new() { UserId = createOrderDTO.UserId, SupplierId = createOrderDTO.SupplierId, Name = createOrderDTO.Name, Description = createOrderDTO.Description, ExpireDate = createOrderDTO.ExpireDate });
            return await _orderRepository.SaveAsync() > 0;
        }

        public async Task<bool> DeleteOrderById(string id)
        {
            await _orderRepository.RemoveAsync(id);
            return await _orderRepository.SaveAsync() > 0;
        }

        public async Task<List<ListOrderDTO>> GetAllOrders()
        {
            List<ListOrderDTO> orders = await _orderRepository.GetAll().Select(o => new ListOrderDTO()
            {
                Id = o.Id.ToString(),
                Description = o.Description,
                ExpireDate = o.ExpireDate,
                Name = o.Name,
                SupplierId = o.SupplierId,
                UserId = o.UserId,
            }).ToListAsync();
            return orders;
        }

        public async Task<OrderDTO> GetOrderById(string id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order != null)
                return new()
                {
                    Id = order.Id.ToString(),
                    UserId = order.UserId,
                    SupplierId = order.SupplierId,
                    Name = order.Name,
                    ExpireDate= order.ExpireDate,
                    CreatedDate= order.CreatedDate,
                    Description = order.Description

                };
            else
                throw new Exception("Order Not Found");
        }

        public async Task<bool> UpdateOrder(UpdateOrderDTO updateOrderDTO)
        {
            var order = await _orderRepository.GetByIdAsync(updateOrderDTO.Id, true);

            if (order == null)
                throw new Exception("Order Not Found");

            return _orderRepository.Update(order);
        }
    }
}