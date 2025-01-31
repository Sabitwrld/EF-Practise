using EF_Practise.Entities.Common;

namespace EF_Practise.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public List<Model> Models { get; set; }
    }
}
