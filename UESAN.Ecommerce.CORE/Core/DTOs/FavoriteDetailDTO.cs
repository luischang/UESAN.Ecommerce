using System;

namespace UESAN.Ecommerce.CORE.Core.DTOs
{
    public class FavoriteDetailDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public FavoriteProductDTO Product { get; set; }
        public FavoriteUserDTO User { get; set; }
    }
}