using System;
using System.Collections.Generic;

namespace ProiectDAW.Models.DTOs
{
    public class ModelResultDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Guid StudentId { get; set; }
        public string Password { get; set; }
        //public List<Model2> Models2 { get; set; }
    }
}
