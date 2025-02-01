using EF_Practise.Data;
using EF_Practise.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();

            var displayCars = context.Cars
              .Include(c => c.Model)
              .ThenInclude(m => m.Brand)
              .Include(c => c.CarColors)
              .ThenInclude(cc => cc.Color)
              .ToList();

            foreach (var car in displayCars)
            {
                Console.WriteLine($"Id - {car.Id}" + " , " +
                                  $"Brand - {car.Model.Brand.Name}" + " , " +
                                  $"Model - {car.Model.Name}" + " , " +
                                  $"MaxSpeed - {car.MaxSpeed}" + " , " +
                                  $"Fuel Capacity - {car.FuelTankCapacity}" + " , " +
                                  $"Power - {car.Power}" + " , " +
                                  $"Door Count - {car.DoorCount}");
            }

        }
        
    
    }
}
