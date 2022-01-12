using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.One_to_Many
{
    public class Model2 : BaseEntity
    {
        string Name { get; set; }

        public Model1 Model1 { get; set; }

        public Guid Model1Id { get; set; }
    }
}
