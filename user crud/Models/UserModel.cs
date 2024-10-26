using System.ComponentModel.DataAnnotations;

namespace user_crud.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string? Username { get; set; } = null;

        [Required]
        public string? Email { get; set; } = null;

        public string? PhoneNumber { get; set; } = null;

        public string? Address { get; set; } = null;

        public string? Zip { get; set; } = null;

        public string? City { get; set; } = null;
    }
}
