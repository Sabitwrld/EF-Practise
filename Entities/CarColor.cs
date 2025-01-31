using EF_Practise.Entities.Common;

namespace EF_Practise.Entities
{
    public class CarColor : BaseEntity
    {
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
