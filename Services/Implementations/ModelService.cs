using EF_Practise.Data;
using EF_Practise.Entities;
using EF_Practise.PB503CarShopExceptions;
using EF_Practise.Repositeries.Interfaces;
using EF_Practise.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF_Practise.Services.Implementations
{
    public class ModelService : IModelService
    {
        private readonly IGenericRepository<Model> _repository;
        private readonly AppDbContext _context;

        public ModelService(IGenericRepository<Model> repository)
        {
            _repository = repository;
        }

        public void Create(Model model)
        {
            if (model is null)
                throw new CustomException("Model cannot be null");

            _repository.Add(model);
        }

        public void Delete(int id)
        {
            var model = _repository.GetById(id);

            if (model is null)
                throw new CustomException($"Model with id {id} not found");

            _repository.Delete(model);
        }

        public List<Model> GetAll()
        {
            var models = _context.Models
                         .Include(m => m.Brand)
                         .Include(m => m.Cars)
                         .ToList();

            if (models is null)
                throw new CustomException("No models found");

            return models;
        }

        public Model GetById(int id)
        {
            var model = _context.Models
                        .Include(m => m.Brand)
                        .Include(m => m.Cars)
                        .FirstOrDefault(m => m.Id == id);

            if (model is null)
                throw new CustomException($"Model with id {id} not found");

            return model;
        }

        public void Update(int id, Model model)
        {
            if (model is null)
                throw new CustomException("Model cannot be null");

            var existingModel = _repository.GetById(id);

            if (existingModel is null)
                throw new CustomException($"Model with id {id} not found");

            existingModel.Name = model.Name;
            _repository.Update(id, existingModel);
        }
    }
}
