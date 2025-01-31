using EF_Practise.DTOs.Brand;
using EF_Practise.Entities;
using EF_Practise.PB503CarShopExceptions;
using EF_Practise.Repositeries.Interfaces;
using EF_Practise.Services.Interfaces;

namespace EF_Practise.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _repository;

        public BrandService(IGenericRepository<Brand> repository)
        {
            _repository = repository;
        }

        public void Create(BrandCreateDto brandDto)
        {
            if (brandDto is null) throw new CustomException("Brand cannot be null");
            if (brandDto.Name is null) throw new CustomException("Brand name cannot be null");
            var brand = new Brand();
            brand.Name = brandDto.Name;
            _repository.Add(brand);
        }

        public void Delete(int? id)
        {  
            if (id is null) throw new CustomException("Id cannot be null");
            var existsBrand = _repository.GetById((int)id);
            if (existsBrand is null) throw new CustomException("Brand cannot be null");
            _repository.Delete(existsBrand);
        }

        public List<BrandGetDto> GetAll()
        {
            var brands = _repository.GetAll();
            var brandDto = new List<BrandGetDto>();
            foreach (var item in brands)
            {
                var brandGetDto = new BrandGetDto();
                item.Name = brandGetDto.Name;
                brandDto.Add(brandGetDto);
            }
            return brandDto;
        }

        public Brand GetById(int id)
        {

        }

        public void Update(int id, Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
