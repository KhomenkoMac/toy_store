using entities;
using entities.DTO;

namespace entity_framework.DataServices
{
    public class DataMutatorServiceAdapter<T> : IDataMutator<T> where T : DTO
    {
        private readonly IDataMutatorService<T> _dataMutatorService;
        public DataMutatorServiceAdapter(IDataMutatorService<T> dataMutatorService)
        {
            _dataMutatorService = dataMutatorService;
        }

        public T AddWithNetsted(T entity)
        {
            return _dataMutatorService.AddWithNetsted(entity).Result;
        }

        public T Insert(T entity)
        {
            return _dataMutatorService.Insert(entity).Result;
        }

        public T Remove(int id)
        {
            return _dataMutatorService.Remove(id).Result;
        }

        public T Update(T entity)
        {
            return _dataMutatorService.Update(entity).Result;
        }
    }
}
