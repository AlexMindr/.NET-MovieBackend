using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class Movie: BaseEntity 
    {
        public bool Adult { get; set; }
        public string Title { get; set; }
        public string? Duration { get; set; }
        public int? Budget { get; set; }
        public string? PosterPath { get; set; }

        public string? Language { get; set; }
        public DateTime? ReleaseDate { get; set; }
        
    }
}
