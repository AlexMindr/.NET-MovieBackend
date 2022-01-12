using ProiectDAW.Models.Base;

namespace ProiectDAW.Models.One_to_One
{
    public class Model5: BaseEntity
    {
        public string Name { get; set; }

        public Model6 Model6 { get; set; }
    }
}
