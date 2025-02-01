using EF_Practise.Data;
using EF_Practise.Entities;
using EF_Practise.PB503CarShopExceptions;
using EF_Practise.Repositeries.Interfaces;
using EF_Practise.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF_Practise.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _repository;
        private readonly AppDbContext _context;

        public BrandService(IGenericRepository<Brand> repository)
        {
            _repository = repository;
        }

        public void Create(Brand brand)
        {
            if (brand is null)
                throw new CustomException("Brand cannot be null");

            _repository.Add(brand);
        }

        public void Delete(int id)
        {
            var brand = _repository.GetById(id);

            if (brand is null)
                throw new CustomException($"Brand with id {id} not found");

            _repository.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            var brands = _context.Brands
                         .Include(b => b.Models)
                         .ThenInclude(m => m.Cars)
                         .ToList(); ;

            if (brands is null)
                throw new CustomException("No brands found");

            return brands;
        }

        public Brand GetById(int id)
        {
            var brand = _context.Brands
                        .Include(b => b.Models)
                        .ThenInclude(m => m.Cars)
                        .FirstOrDefault(b => b.Id == id);

            if (brand is null)
                throw new CustomException($"Brand with id {id} not found");

            return brand;
        }

        public void Update(int id, Brand brand)
        {
            if (brand is null)
                throw new CustomException("Brand cannot be null");

            var existingBrand = _repository.GetById(id);

            if (existingBrand is null)
                throw new CustomException($"Brand with id {id} not found");

            existingBrand.Name = brand.Name;
            _repository.Update(id, existingBrand);
        }
    }
}
