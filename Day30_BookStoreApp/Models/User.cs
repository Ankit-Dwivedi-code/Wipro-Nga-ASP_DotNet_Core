using System.ComponentModel.DataAnnotations;

namespace Day30_BookStoreApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        public string Role { get; set; } = "User"; // default role
    }
}
