using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models.Many_to_Many
{
    public class Model4: BaseEntity
    {
        public string Name { get; set; }

        //public ICollection<Model3> Models3 { get; set; }
        public ICollection<ModelsRelation> ModelsRelations { get; set; }

    }
}
