using ProiectDAW.Models.Base;
using System.Collections.Generic;

namespace ProiectDAW.Models.One_to_Many
{
    public class Model1: BaseEntity
    {
        string Name { get; set; }

        public ICollection<Model2> Models2 { get; set; }
    }
}
