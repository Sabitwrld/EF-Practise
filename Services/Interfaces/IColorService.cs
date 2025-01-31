using EF_Practise.Entities;

namespace EF_Practise.Services.Interfaces
{
    public interface IColorService
    {
        void Create(Color color);
        void Update(int id, Color color);
        void Delete(int id);
        Color GetById(int id);
        List<Color> GetAll();
    }
}
