using entities.Factory;
using System.Threading.Tasks;

namespace entity_framework.DataServices.Mutators
{
    public abstract class MutationTemplateMethod<TOperatationRes, TOperationEntryParams>
    {
        private readonly IToyStoreContextCreator _toyStoreDataContextCreator;
        protected readonly TOperationEntryParams _param;

        protected MutationTemplateMethod(TOperationEntryParams param, IToyStoreContextCreator toyStoreDataContextCreator)
        {
            _param = param;
            _toyStoreDataContextCreator = toyStoreDataContextCreator;
        }

        public async Task<TOperatationRes> ExecMutation()
        {
            using (var context = _toyStoreDataContextCreator.CreateContext())
            {
                TOperatationRes operatationRes = await Exceute(context);
                await context.SaveChangesAsync();
                return operatationRes;
            }
        }
        public abstract Task<TOperatationRes> Exceute(ToyStoreDataContext context);

    }

    
}
