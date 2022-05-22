using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.Services
{
    public interface IDataService<T> where T : class
    {
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> ReadBy(int id);
        Task<IEnumerable<T>> ReadAll();
    }
}
