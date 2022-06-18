using entities;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class TheAuthentication
    {
        private readonly IDataProviderService<entities.DTO.User> _usersProvider;
        private readonly IDataMutatorService<entities.DTO.User> _usersMutator;
        private readonly IDataProviderService<entities.DTO.Profile> _profileProvider;
        private readonly IDataMutatorService<entities.DTO.Profile> _profileMutator;

        public TheAuthentication(
            IDataProviderService<entities.DTO.User> usersProvider,
            IDataMutatorService<entities.DTO.User> usersMutator,
            IDataMutatorService<entities.DTO.Profile> profileMutator, 
            IDataProviderService<entities.DTO.Profile> profileProvider)
        {
            _usersProvider = usersProvider;
            _usersMutator = usersMutator;
            _profileMutator = profileMutator;
            _profileProvider = profileProvider;
        }

        public async Task SignUp(User incomingCredentials)
        {
            if (!await IsRegisterd(incomingCredentials.Login))
            {
                var newDTOUser = incomingCredentials.ToDto();
                await _usersMutator.Insert(newDTOUser);
                var newProfile = new entities.DTO.Profile()
                {
                    UserId = newDTOUser.Id,
                };
                await _profileMutator.Insert(newProfile);
                Debug.WriteLine("Signed up!!!", "Sign up");
            }
        }

        public async Task<entities.DTO.Profile> SignIn(User user)
        {
            var users = await _usersProvider.ReadAll();
            var authorized = users.Where(obj => obj.Login == user.Login).Where(obj => obj.Password == user.Password).FirstOrDefault();
            if (authorized != null)
            {
                var profs = await _profileProvider.ReadAll();
                var profile = profs.Where(obj => obj.UserId == authorized.Id).FirstOrDefault();

                return profile;
            }
            return null;
        }

        private async Task<bool> IsRegisterd(string login)
        {
            var usersFromBase = await _usersProvider.ReadAll();
            return usersFromBase.FirstOrDefault(obj => obj.Login == login) != null;
        }
    }
}
