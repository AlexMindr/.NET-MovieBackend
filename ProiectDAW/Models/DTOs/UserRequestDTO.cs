using System.ComponentModel.DataAnnotations;

namespace ProiectDAW.Models.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
    }
}
