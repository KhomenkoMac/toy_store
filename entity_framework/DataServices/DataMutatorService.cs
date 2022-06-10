using entities;
using entities.DTO;
using entity_framework.Factory;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace entity_framework.DataServices
{
    public class DataMutatorService<T>: IDataMutatorService<T> where T : DTO 
    {
        private readonly IToyStoreContextCreator _toyStoreContextCreator;

        public DataMutatorService(IToyStoreContextCreator toyStoreContextCreator)
        {
            _toyStoreContextCreator = toyStoreContextCreator;
        }

        public async Task<T> AddWithNetsted(T entity)
        {
            using (var context = _toyStoreContextCreator.CreateContext())
            {
                context.Set<T>().Attach(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<T> Insert(T entity)
        {
            using (var context = _toyStoreContextCreator.CreateContext())
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<T> Remove(int id)
        {
            using (var context = _toyStoreContextCreator.CreateContext())
            {
                var entity_to_delete = await context.Set<T>().FirstOrDefaultAsync(obj => obj.Id == id);
                context.Set<T>().Remove(entity_to_delete);
                await context.SaveChangesAsync();
                return entity_to_delete;
            }
        }

        public async Task<T> Update(T entity)
        {
            using (var context = _toyStoreContextCreator.CreateContext())
            {
                var upd_ent = context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return upd_ent.Entity;
            }
        }
    }
}
