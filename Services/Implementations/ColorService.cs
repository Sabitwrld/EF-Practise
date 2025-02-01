using EF_Practise.Entities;
using EF_Practise.PB503CarShopExceptions;
using EF_Practise.Repositeries.Interfaces;
using EF_Practise.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practise.Services.Implementations
{
    public class ColorService : IColorService
    {
        private readonly IGenericRepository<Color> _repository;

        public ColorService(IGenericRepository<Color> repository)
        {
            _repository = repository;
        }

        public void Create(Color color)
        {
            if (color is null)
                throw new CustomException("Model cannot be null");

            _repository.Add(color);
        }

        public void Delete(int id)
        {
            var color = _repository.GetById(id);

            if (color is null)
                throw new CustomException($"Color with id {id} not found");

            _repository.Delete(color);
        }

        public List<Color> GetAll()
        {
            var colors = _repository.GetAll();

            if (colors is null)
                throw new CustomException("No colors found");

            return colors;
        }

        public Color GetById(int id)
        {
            var color = _repository.GetById(id);

            if (color is null)
                throw new CustomException($"Color with id {id} not found");

            return color;
        }

        public void Update(int id, Color color)
        {
            if (color is null)
                throw new CustomException("Color cannot be null");

            var existingColor = _repository.GetById(id);

            if (existingColor is null)
                throw new CustomException($"Color with id {id} not found");

            existingColor.Name = color.Name;
            _repository.Update(id, existingColor);
        }
    }
}
