using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.Entities
{
    public class Trailer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateModified { get; set; }

        [Key]
        [Required(ErrorMessage = "MovieId is required")]
        public Guid MovieId { get; set; }

        public string? Path { get; set; }

        public virtual Movie Movie { get; set; }

    }
}
