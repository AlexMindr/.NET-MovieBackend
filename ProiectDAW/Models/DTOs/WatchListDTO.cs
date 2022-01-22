using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.DTOs
{
    public class WatchListItemDTO
    {
        public Guid userId;
        public Guid movieId;
        public string Status;
        public string Title;
        public int Rating;
    }
}
