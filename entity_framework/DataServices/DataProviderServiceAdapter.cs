using entities;
using entities.DTO;
using System.Collections.Generic;

namespace entity_framework.DataServices
{
    public class DataProviderServiceAdapter<T> : IDataProvider<T> where T : DTO
    {
        private readonly IDataProviderService<T> _dataProviderService;
        public DataProviderServiceAdapter(IDataProviderService<T> dataProviderService)
        {
            _dataProviderService = dataProviderService;
        }

        public ICollection<T> ReadAll()
        {
            return _dataProviderService.ReadAll().Result;
        }

        public T ReadBy(int id)
        {
            return _dataProviderService.ReadBy(id).Result;
        }
    }
}
