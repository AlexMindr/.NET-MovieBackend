using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class MovieGenre
    {
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
