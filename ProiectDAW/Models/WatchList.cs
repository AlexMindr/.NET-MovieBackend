using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class WatchList
    {

        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public int? Rating { get; set; }
        public string Status { get; set; }
    }
}
