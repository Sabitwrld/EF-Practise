using EF_Practise.Data;
using EF_Practise.Entities;
using EF_Practise.PB503CarShopExceptions;
using EF_Practise.Repositeries.Interfaces;
using EF_Practise.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF_Practise.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _repository;
        private readonly AppDbContext _context;

        public CarService(IGenericRepository<Car> repository)
        {
            _repository = repository;
        }

        public void Create(Car car)
        {
            if (car is null)
                throw new CustomException("Car cannot be null");

            _repository.Add(car);
        }

        public void Delete(int id)
        {
            var car = _repository.GetById(id);

            if (car is null)
                throw new CustomException($"Car with id {id} not found");

            _repository.Delete(car);
        }

        public List<Car> GetAll()
        {
            var cars = _context.Cars
                .Include(c => c.Model)
                .ThenInclude(m => m.Brand)
                .Include(c => c.CarColors)
                .ThenInclude(cc => cc.Color)
                .ToList();

            if (cars is null)
                throw new CustomException("No cars found");

            return cars;
        }

        public Car GetById(int id)
        {
            var car = _context.Cars
                 .Include(c => c.Model)
                 .ThenInclude(m => m.Brand)
                 .Include(c => c.CarColors)
                 .ThenInclude(cc => cc.Color)
                 .FirstOrDefault(c => c.Id == id);

            if (car is null)
                throw new CustomException($"Car with id {id} not found");

            return car;
        }

        public void Update(int id, Car car)
        {
            if (car is null)
                throw new CustomException("Car cannot be null");

            var existingCar = _context.Cars
                .Include(c => c.Model)
                .Include(c => c.CarColors)
                .FirstOrDefault(c => c.Id == id);

            if (existingCar is null)
                throw new CustomException($"Car with id {id} not found");

            existingCar.MaxSpeed = car.MaxSpeed;
            existingCar.FuelTankCapacity = car.FuelTankCapacity;
            existingCar.Power = car.Power;
            existingCar.DoorCount = car.DoorCount;
            existingCar.ModelId = car.ModelId;

            existingCar.Model = car.Model;
            existingCar.CarColors = car.CarColors;

            _repository.Update(id, existingCar);
        }
    }
}
