using EF_Practise.Entities.Common;

namespace EF_Practise.Repositeries.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        void Add(T entity);
        void Update(int id,T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
