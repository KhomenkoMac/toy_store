using entities;
using entities.DTO;
using entity_framework.Factory;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework.DataServices
{
    public class DataProviderService<T> : IDataProviderService<T> where T : DTO
    {
        private readonly IToyStoreContextCreator _toyStoreContextCreator;

        public DataProviderService(IToyStoreContextCreator toyStoreContextCreator)
        {
            _toyStoreContextCreator = toyStoreContextCreator;
        }

        public async Task<ICollection<T>> ReadAll()
        {
            using (var context = _toyStoreContextCreator.CreateContext())
            {
                var ents = await context.Set<T>().ToListAsync();
                ents.ForEach(i => LoadAllPropsForEntity(context, i));
                return ents;
            }
        }

        public async Task<T> ReadBy(int id)
        {
            using (var context = _toyStoreContextCreator.CreateContext())
            {
                var entity = await context.Set<T>().FirstAsync();
                LoadAllPropsForEntity(context, entity);
                return entity;
            }
        }

        private static void LoadAllPropsForEntity(ToyStoreDataContext context, T entity)
        {
            context.Entry(entity).Navigations.ToList().ForEach(obj => obj.Load());
        }
    }
}
