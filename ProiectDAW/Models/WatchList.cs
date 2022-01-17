using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Range(0, 5, ErrorMessage = "The value must be greater than 0 and smaller or equal to 5")]
        public int? Rating { get; set; }
        public string Status { get; set; }
    }
}
