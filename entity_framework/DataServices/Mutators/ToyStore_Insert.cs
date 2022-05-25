using entities.DTO;
using entities.Factory;
using System.Threading.Tasks;

namespace entity_framework.DataServices.Mutators
{
    public class ToyStore_Insert<TEntity> : MutationTemplateMethod<TEntity, TEntity> where TEntity : DTO
    {
        public ToyStore_Insert(TEntity param, IToyStoreContextCreator result): base(param, result) { }

        public override async Task<TEntity> Exceute(ToyStoreDataContext context)
        {
            await context.Set<TEntity>().AddAsync(_param);
            return _param;
        }
    }

    
}
