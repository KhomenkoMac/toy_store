using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class TheCart
    {
        private readonly IDataProviderService<entities.DTO.Toy> _toyProvider;
        private readonly IDataProviderService<entities.DTO.User> _usersProvider;
        private readonly IDataProviderService<entities.DTO.Profile> _profileProvider;
        private readonly IDataProviderService<entities.DTO.ProfileToy> _profileToyProvider;
        private readonly IDataMutatorService<entities.DTO.ProfileToy> _profileToyDataMutator;

        public TheCart(
            IDataProviderService<entities.DTO.Toy> toyDataProviderService,
            IDataProviderService<entities.DTO.Profile> profileDataProvider,
            IDataProviderService<entities.DTO.ProfileToy> profileToyDataProvider,
            IDataMutatorService<entities.DTO.ProfileToy> profileToyDataMutator, 
            IDataProviderService<entities.DTO.User> usersProvider)
        {
            _toyProvider = toyDataProviderService;
            _profileProvider = profileDataProvider;
            _profileToyProvider = profileToyDataProvider;
            _profileToyDataMutator = profileToyDataMutator;
            _usersProvider = usersProvider;
        }

        public async Task AddToCart(Profile profile, Toy toy)
        {
            int toyId = toy.Id;
            int profId = profile.ProfileId;

            var foundToy = await _toyProvider.ReadBy(toyId);
            var foundProfile = await _profileProvider.ReadBy(profId);

            if (foundToy == null || foundProfile == null)
            {
                return;
            }

            var profileToy = await _profileToyProvider.ReadAll();
            bool toyAlreadyAdded = ToyIsInTheCart(foundToy, foundProfile, profileToy);

            if (toyAlreadyAdded)
            {
                return;
            }

            await _profileToyDataMutator.Insert(new entities.DTO.ProfileToy
            {
                ProfileId = foundProfile.Id,
                ToyId = foundToy.Id
            });
        }


        public async Task DeleteFromCart(Profile profile, Toy toy)
        {
            int profId = profile.ProfileId;
            int toyId = toy.Id;

            var existingItems = await RetriveProfileAndToy(profId, toyId);
            var foundToy = existingItems.Item1;
            var foundProfile = existingItems.Item2;
            if (foundToy == null || foundProfile == null)
            {
                return;
            }

            var profileToy = await _profileToyProvider.ReadAll();
            
            if (!ToyIsInTheCart(foundToy, foundProfile, profileToy))
            {
                return;
            }

            await _profileToyDataMutator.Remove(GetTheRelation(foundToy, foundProfile, profileToy).Id);
        }

        public async Task<ICollection<Toy>> GetIncartToys(Profile profile)
        {
            List<Toy> toys = new();

            var relations = await _profileToyProvider.ReadAll();
            var toyIds = relations.Where(obj => obj.ProfileId == profile.ProfileId).Select(obj=> obj.ToyId);

            foreach (var id in toyIds)
            {
                var toyToAdd = await _toyProvider.ReadBy(id);
                toys.Add(toyToAdd.FromDto());
            }
            return toys;
        }
        
        private static bool ToyIsInTheCart(entities.DTO.Toy foundToy, entities.DTO.Profile foundProfile, ICollection<entities.DTO.ProfileToy> profileToy)
        {
            return GetTheRelation(foundToy, foundProfile, profileToy) is not null;
        }

        private static entities.DTO.ProfileToy GetTheRelation(entities.DTO.Toy foundToy, entities.DTO.Profile foundProfile, ICollection<entities.DTO.ProfileToy> profileToy)
        {
            return profileToy.Where(obj => obj.ToyId == foundToy.Id).Where(obj => obj.ProfileId == foundProfile.Id).FirstOrDefault();
        }

        private async Task<Tuple<entities.DTO.Toy, entities.DTO.Profile>> RetriveProfileAndToy(int profileId, int toyId)
        {
            var foundToy = await _toyProvider.ReadBy(toyId);
            var foundProfile = await _profileProvider.ReadBy(profileId);
            
            return new Tuple<entities.DTO.Toy, entities.DTO.Profile>(foundToy, foundProfile);
        }

    }
}
