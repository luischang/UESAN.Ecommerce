using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreDbContext _context;

        public OrdersRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrderAsync(Orders order, IEnumerable<OrderDetail> details)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach (var detail in details)
            {
                detail.OrdersId = order.Id;
                await _context.OrderDetail.AddAsync(detail);
            }
            await _context.SaveChangesAsync();
            return order.Id;
        }
    }
}