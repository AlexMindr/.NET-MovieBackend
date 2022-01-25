using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.DTOs
{
    public class WatchListItemDTO
    {
        public Guid userId { get; set; }
        public Guid movieId { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
    }
}
