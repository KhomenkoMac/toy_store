using entities.DTO;
using entities.Factory;
using System.Threading.Tasks;

namespace entity_framework.DataServices.Mutators
{
    public class ToyStore_Delete<TEntity> : MutationTemplateMethod<bool, TEntity> where TEntity : DTO
    {
        public ToyStore_Delete(TEntity param, IToyStoreContextCreator result) : base(param, result) { }
        public override async Task<bool> Exceute(ToyStoreDataContext context)
        {
            context.Set<TEntity>().Remove(_param);
            return true;
        }

    }

}
