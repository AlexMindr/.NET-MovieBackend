using System.ComponentModel.DataAnnotations;

namespace ProiectDAW.Models.DTOs
{
    public class UserAuthDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
        
    }
}
