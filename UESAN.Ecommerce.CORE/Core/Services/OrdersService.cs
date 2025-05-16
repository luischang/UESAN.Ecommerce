using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using System.Collections.Generic;

namespace UESAN.Ecommerce.CORE.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<int> CreateOrderAsync(OrdersDTO orderDto)
        {
            var order = new Orders
            {
                UserId = orderDto.UserId,
                CreatedAt = System.DateTime.UtcNow,
                Status = "A",
                TotalAmount = orderDto.TotalAmount
            };
            var details = new List<OrderDetail>();
            foreach (var d in orderDto.OrderDetails)
            {
                details.Add(new OrderDetail
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    Price = d.Price,
                    CreatedAt = System.DateTime.UtcNow
                });
            }
            return await _ordersRepository.CreateOrderAsync(order, details);
        }
    }
}