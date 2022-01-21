using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.DTOs
{
    public class WatchListDTO
    {
        public Guid userId;
        public List<Guid> movieids;
        public List<string> statuses;
        public List<string> names;
        public List<int> ratings;
    }
}
