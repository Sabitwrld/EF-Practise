using EF_Practise.Entities;

namespace EF_Practise.Services.Interfaces
{
    public interface ICarService
    {
        void Create(Car car);
        void Update(int id,Car car);
        void Delete(int id);
        Car GetById(int id);
        List<Car> GetAll();
    }
}
