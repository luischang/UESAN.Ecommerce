using System;
using System.Collections.Generic;

namespace UESAN.Ecommerce.CORE.Core.DTOs
{
    public class OrdersDTO
    {
        public int? UserId { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}