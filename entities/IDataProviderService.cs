using System.Collections.Generic;
using System.Threading.Tasks;

namespace entities
{
    public interface IDataProviderService<T>
    {
        Task<ICollection<T>> ReadAll();
        Task<T> ReadBy(int id);
    }
}
