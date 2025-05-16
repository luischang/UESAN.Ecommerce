namespace UESAN.Ecommerce.CORE.Core.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }
    }
}