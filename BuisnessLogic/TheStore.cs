using entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class TheStore
    {
        private readonly IDataMutatorService<entities.DTO.Toy> _toysDataMutatorService;
        private readonly IDataProviderService<entities.DTO.Toy> _toysDataProviderService;
        private readonly IDataProviderService<entities.DTO.User> _usersDataProviderService;

        public TheStore(
            IDataMutatorService<entities.DTO.Toy> toysDataMutatorService,
            IDataProviderService<entities.DTO.Toy> toysDataProviderService,
            IDataProviderService<entities.DTO.User> usersDataProviderService)
        {
            _toysDataMutatorService = toysDataMutatorService;
            _toysDataProviderService = toysDataProviderService;
            _usersDataProviderService = usersDataProviderService;
        }

        public async Task<ICollection<Toy>> GetAllToys()
        {
            var dto_toys = await _toysDataProviderService.ReadAll();
            return dto_toys.Select(obj => obj.FromDto()).ToList();
        }

        public async Task<Toy> GetToy(int toyId)
        {
            var res = await _toysDataProviderService.ReadBy(toyId);
            return res.FromDto();
        }

        public async Task AddToStore(Toy toy)
        {
            var dto_toy = toy.ToDto();
            await _toysDataMutatorService.AddWithNetsted(dto_toy);
        }

        public async Task DeleteFromStore(int toy_id)
        {
            await _toysDataMutatorService.Remove(toy_id);
        }

    }


}
