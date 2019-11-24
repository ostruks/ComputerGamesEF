using System.Collections.Generic;

namespace DAL
{
    public interface IController<T> where T : class
    {
        ICollection<T> GetAll(int license = 0);
        T GetById(int id);
        T Create(T tclass);
        void Update(string name, T tclass);
        void DeleteById(int id);
        void Delete(T tclass);
    }
}
