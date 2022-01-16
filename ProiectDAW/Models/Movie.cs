using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class Movie: BaseEntity 
    {   
        [Required(ErrorMessage = "AgeRange is required")]
        public bool Adult { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string? Duration { get; set; }
        public int? Budget { get; set; }
        public string? PosterPath { get; set; }
        public string? Language { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public float? Rating { get; set; }
        public virtual Trailer Trailer { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }


        public virtual ICollection<WatchList> WatchLists { get; set; }

    }
}
