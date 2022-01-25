using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.DTOs
{
    public class WatchListCreateDTO
    {
        //public Guid userId;
        public Guid movieId { get; set; }
        public string Status { get; set; }
        public int Rating { get; set; }
    }
}
