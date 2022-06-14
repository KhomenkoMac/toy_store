using entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessLogic
{

    public class TheCart
    {
        private readonly IDataProvider<entities.DTO.Toy> _toyDataProviderService;
        private readonly IDataProvider<entities.DTO.User> _usersDataProviderService;
        private readonly IDataMutator<entities.DTO.Profile> _profileDataMutatorService;

        public TheCart(
            IDataProvider<entities.DTO.Toy> dataProviderService,
            IDataProvider<entities.DTO.User> usersDataProviderService,
            IDataMutator<entities.DTO.Profile> profileDataMutatorService)
        {
            _toyDataProviderService = dataProviderService;
            _usersDataProviderService = usersDataProviderService;
            _profileDataMutatorService = profileDataMutatorService;
        }

        public bool AddToCart(int userId, int toyId)
        {
            var res = FindToyInTheCart(userId, toyId);
            res.Item2.Toys.Add(res.Item1);
            _profileDataMutatorService.Update(res.Item2);
            return true;
        }
        
        public void DeleteFromCart(int userId, int toyId)
        {
            var res = FindToyInTheCart(userId, toyId);
            res.Item2.Toys.Remove(res.Item1);
            _profileDataMutatorService.Update(res.Item2);
        }

        public ICollection<Toy> GetIncartToys(int userId)
        {
            var user = _usersDataProviderService.ReadBy(userId);
            return user.UserProfile.Toys.ToList().Select(obj => obj.FromDto()).ToList();
        }

        private Tuple<entities.DTO.Toy, entities.DTO.Profile> FindToyInTheCart(int userId, int toyId)
        {
            var toyToAdd = _toyDataProviderService.ReadBy(toyId);
            var user = _usersDataProviderService.ReadBy(userId);
            return new(toyToAdd, user.UserProfile);
        }

    }
}
