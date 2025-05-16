using System.Collections.Generic;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IOrdersRepository
    {
        Task<int> CreateOrderAsync(Orders order, IEnumerable<OrderDetail> details);
        // Otros métodos como Get, Update, Delete pueden agregarse según necesidad
    }
}