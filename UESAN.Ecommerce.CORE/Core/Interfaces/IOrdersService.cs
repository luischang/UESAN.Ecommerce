using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<int> CreateOrderAsync(OrdersDTO orderDto);
        // Otros métodos como Get, Update, Delete pueden agregarse según necesidad
    }
}