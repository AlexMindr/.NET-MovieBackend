using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class Admin:BaseEntity
    {
        public string Type { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
