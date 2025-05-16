namespace UESAN.Ecommerce.CORE.Core.DTOs
{
    public class OrderDetailDTO
    {
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}