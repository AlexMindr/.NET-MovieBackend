﻿using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public virtual ICollection<WatchList> WatchLists { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
