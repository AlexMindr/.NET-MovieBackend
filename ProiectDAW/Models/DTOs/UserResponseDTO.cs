using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.DTOs
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }


        public UserResponseDTO(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
            Role = user.Role;
        }
    }
}
