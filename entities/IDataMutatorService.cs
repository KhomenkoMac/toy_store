using System.Threading.Tasks;

namespace entities
{
    public interface IDataMutatorService<T>
    {
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Remove(int id);
        Task<T> AddWithNetsted(T entity);
    }
}
