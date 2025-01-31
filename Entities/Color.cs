using EF_Practise.Entities.Common;

namespace EF_Practise.Entities
{
    public class Color : BaseEntity
    {
        public string? Name { get; set; }
        public List<CarColor> CarColors { get; set; }
    }
}
