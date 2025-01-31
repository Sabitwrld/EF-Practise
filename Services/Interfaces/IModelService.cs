using EF_Practise.Entities;

namespace EF_Practise.Services.Interfaces
{
    public interface IModelService
    {
        void Create(Model model);
        void Update(int id, Model model);
        void Delete(int id);
        Model GetById(int id);
        List<Model> GetAll();
    }
}
