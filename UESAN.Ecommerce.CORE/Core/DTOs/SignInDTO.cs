namespace UESAN.Ecommerce.CORE.Core.DTOs
{
    public class SignInRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInResponseDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? Type { get; set; }
        public string Token { get; set; }
    }
}
