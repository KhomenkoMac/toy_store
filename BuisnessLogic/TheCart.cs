using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLogic
{

    public class TheCart
    {
        private readonly IDataProviderService<entities.DTO.Toy> _toyDataProviderService;
        private readonly IDataProviderService<entities.DTO.User> _usersDataProviderService;
        private readonly IDataMutatorService<entities.DTO.Profile> _profileDataMutatorService;

        public TheCart(
            IDataProviderService<entities.DTO.Toy> dataProviderService,
            IDataProviderService<entities.DTO.User> usersDataProviderService,
            IDataMutatorService<entities.DTO.Profile> profileDataMutatorService)
        {
            _toyDataProviderService = dataProviderService;
            _usersDataProviderService = usersDataProviderService;
            _profileDataMutatorService = profileDataMutatorService;
        }

        public async Task<bool> AddToCart(int userId, int toyId)
        {
            var res = await FindToyInTheCart(userId, toyId);
            res.Item2.Toys.Add(res.Item1);
            await _profileDataMutatorService.Update(res.Item2);
            return true;
        }
        
        public async Task DeleteFromCart(int userId, int toyId)
        {
            var res = await FindToyInTheCart(userId, toyId);
            res.Item2.Toys.Remove(res.Item1);
            await _profileDataMutatorService.Update(res.Item2);
        }

        public async Task<ICollection<Toy>> GetIncartToys(int userId)
        {
            var user = await _usersDataProviderService.ReadBy(userId);
            return user.UserProfile.Toys.ToList().Select(obj => obj.FromDto()).ToList();
        }

        private async Task<Tuple<entities.DTO.Toy, entities.DTO.Profile>> FindToyInTheCart(int userId, int toyId)
        {
            var toyToAdd = await _toyDataProviderService.ReadBy(toyId);
            var user = await _usersDataProviderService.ReadBy(userId);
            return new(toyToAdd, user.UserProfile);
        }

    }
}
