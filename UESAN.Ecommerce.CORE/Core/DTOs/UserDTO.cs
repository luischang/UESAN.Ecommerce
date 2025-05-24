namespace UESAN.Ecommerce.CORE.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public string? Type { get; set; }
    }

    public class UserListDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }

    public class UserCreateDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? Type { get; set; }
    }
}
