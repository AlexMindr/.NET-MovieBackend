﻿using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class Role: BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        
    }
}
