using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoPark.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        void Create(T item);
        void Delete(int id);
    }
}