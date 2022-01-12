using Microsoft.AspNetCore.Identity;
using ProiectDAW.Models;
using System;

namespace ProiectDAW.Models
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public User User {get; set;}
        public Role Role { get; set; }

    }
}