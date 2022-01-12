using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public Admin Admin { get; set; }
    }
}
