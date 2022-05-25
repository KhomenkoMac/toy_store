using entities.DTO;
using entities.Factory;
using System.Threading.Tasks;

namespace entity_framework.DataServices.Mutators
{
    public class ToyStore_Update<TEntity> : MutationTemplateMethod<bool, TEntity> where TEntity : DTO
    {
        public ToyStore_Update(TEntity param, IToyStoreContextCreator result) : base(param, result) { }
        public override async Task<bool> Exceute(ToyStoreDataContext context)
        {
            context.Set<TEntity>().Update(_param);
            return true;
        }
    }

    //public class ToyStoreRepository<TEntity> where TEntity: DTO
    //{
    //    private readonly IToyStoreContextCreator _toyStoreDataContextCreator;

    //    public ToyStoreRepository(IToyStoreContextCreator toyStoreDataContextCreator)
    //    {
    //        _toyStoreDataContextCreator = toyStoreDataContextCreator;
    //    }
    //    public async Task<bool> Delete(TEntity entity)
    //    {
    //        using (var context = _toyStoreDataContextCreator.CreateContext())
    //        {
    //            context.Set<TEntity>().Remove(entity);
    //            await context.SaveChangesAsync();
    //            return true;
    //        }
    //    }

    //    public async Task<TEntity> Insert(TEntity entity)
    //    {
    //        using (var context = _toyStoreDataContextCreator.CreateContext())
    //        {
    //            var ent = context.Set<TEntity>().Add(entity).Entity;
    //            await context.SaveChangesAsync();
    //            return ent;
    //        }
    //    }

    //    public async Task<IEnumerable<TEntity>> ReadAll()
    //    {
    //        using (var context = _toyStoreDataContextCreator.CreateContext())
    //        {
    //            return await context.Set<TEntity>().ToListAsync();
    //        }
    //    }

    //    public async Task<TEntity> ReadBy(int id)
    //    {
    //        using (var context = _toyStoreDataContextCreator.CreateContext())
    //        {
    //            return await context.Set<TEntity>().FindAsync(id);
    //        }
    //    }

    //    public async Task<TEntity> Update(TEntity entity)
    //    {
    //        using (var context = _toyStoreDataContextCreator.CreateContext())
    //        {
    //            var ent = context.Set<TEntity>().Update(entity);
    //            await context.SaveChangesAsync();
    //            return ent.Entity;
    //        }

    //    }
    //}
}
