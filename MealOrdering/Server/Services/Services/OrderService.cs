using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrdering.Server.Data.Contexts;
using MealOrdering.Server.Data.Models;
using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly MealOrderingDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(MealOrderingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Order Methods

        public async Task<List<OrderDTO>> GetOrdersAsync(DateTime orderDate)
        {
            List<OrderDTO> orderDTOs = await _context.Orders.Include(o => o.Supplier)
                      .Where(o => o.CreatedDate.Date == orderDate.Date)
                      .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider)
                      .OrderBy(o => o.CreatedDate)
                      .ToListAsync();

            return orderDTOs;
        }

        public async Task<OrderDTO> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders.Where(o => o.Id == id)
                      .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync();
        }
        public async Task<OrderDTO> CreateOrderAsync(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDTO)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderDTO.Id);
            if (order == null)
                throw new Exception("Sipariş Bulunamadı");

            _mapper.Map(orderDTO, order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task DeleteOrderAsync(Guid orderId)
        {
            int detailCount = await _context.OrderItems.Where(o => o.OrderId == orderId).CountAsync();

            if (detailCount > 0)
                throw new Exception($"Bu siparişe ait {detailCount} adet alt sipariş var.");

            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null)
                throw new Exception("Sipariş bulunamadı");

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }

        #endregion

        #region OrderItem Methods

        public async Task<List<OrderItemDTO>> GetOrderItemsAsync(Guid orderId)
        {
            return await _context.OrderItems.Where(oi => oi.OrderId == orderId)
                      .ProjectTo<OrderItemDTO>(_mapper.ConfigurationProvider)
                      .OrderBy(oi => oi.CreatedDate)
                      .ToListAsync();
        }

        public async Task<OrderItemDTO> GetOrderItemsByIdAsync(Guid id)
        {
            return await _context.OrderItems.Include(i => i.Order).Where(oi => oi.Id == id)
                      .ProjectTo<OrderItemDTO>(_mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync();
        }


        public async Task<OrderItemDTO> CreateOrderItemAsync(OrderItemDTO orderItemDTO)
        {
            DateTime orderExpireDate = await _context.Orders
                .Where(oi => oi.Id == orderItemDTO.OrderId)
                .Select(oi => oi.ExpireDate)
                .FirstOrDefaultAsync();

            if (orderExpireDate == null)
                throw new Exception("İlgili Siparişin Ana Kaydı Bulunamadı.");

            if (orderExpireDate <= DateTime.Now)
                throw new Exception("Kapanmış Siparişe Yeni Giriş Yapılamaz!!!");


            OrderItem orderItem = _mapper.Map<OrderItem>(orderItemDTO);
            await _context.AddAsync(orderItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task<OrderItemDTO> UpdateOrderItemAsync(OrderItemDTO orderItemDTO)
        {
            OrderItem orderItem = await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == orderItemDTO.Id);
            if (orderItem == null)
                throw new Exception("Sipariş Bulunamadı");

            _mapper.Map(orderItemDTO, orderItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task DeleteOrderItemAsync(Guid orderItemId)
        {
            OrderItem orderItem = await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == orderItemId);
            if (orderItem == null)
                throw new Exception("Sipariş Detayı Bulunamadı");

            _context.OrderItems.Remove(orderItem);

            await _context.SaveChangesAsync();
        }

        #endregion
    }
}