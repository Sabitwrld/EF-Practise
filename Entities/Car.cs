using EF_Practise.Entities.Common;

namespace EF_Practise.Entities
{
    public class Car : BaseEntity
    {
        public double MaxSpeed { get; set; }
        public int FuelTankCapacity { get; set; }
        public int Power { get; set; }
        public int DoorCount { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public List<CarColor> CarColors { get; set; }
    }
}
