using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.DTOs
{
    public class MovieresDTO
    {   [Required]
        public Guid Id;
        [Required(ErrorMessage = "AgeRange is required")]
        public bool Adult { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string? Duration { get; set; }
        public int? Budget { get; set; }
        public string? PosterPath { get; set; }
        public string? Language { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? TmdbId { get; set; }

        public float? Rating { get; set; } 
        public string? TrailerPath { get; set; }

        public ICollection<string> Genresofmovie { get; set; }

    }
}
