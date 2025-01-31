using EF_Practise.Entities.Common;

namespace EF_Practise.Entities
{
    public class Model : BaseEntity
    {
        public string? Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<Car> Cars { get; set; }

    }
}
