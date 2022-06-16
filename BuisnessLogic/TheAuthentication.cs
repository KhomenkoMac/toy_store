using entities;
using entities.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class TheAuthentication
    {
        private readonly IDataProviderService<entities.DTO.User> _usersProvider;
        private readonly IDataMutatorService<entities.DTO.User> _usersMutator;
        private readonly IDataMutatorService<entities.DTO.Profile> _profileMutator;

        public TheAuthentication(
            IDataProviderService<entities.DTO.User> usersProvider, 
            IDataMutatorService<entities.DTO.User> usersMutator, 
            IDataMutatorService<entities.DTO.Profile> profileMutator)
        {
            _usersProvider = usersProvider;
            _usersMutator = usersMutator;
            _profileMutator = profileMutator;
        }

        public async Task SignUp(User incomingCredentials)
        {
            var newDTOUser = incomingCredentials.ToDto();
            await _usersMutator.Insert(newDTOUser);
            var newProfile = new entities.DTO.Profile()
            {
                UserId = newDTOUser.Id
            };
            await _profileMutator.Insert(newProfile);
            //if (!await IsRegisterd(incomingCredentials))
            //{
               
            //}
        }

        public async Task<User> SignIn(User user)
        {
            var users = await _usersProvider.ReadAll();
            return users.Where(obj => obj.Login == user.Login).Where(obj => obj.Password == user.Password).FirstOrDefault().FromDto();
            //if (await IsRegisterd(user))
            //{
            //}
            //return null;
        }

        public async Task<bool> IsRegisterd(User user)
        {
            var usersFromBase = await _usersProvider.ReadAll();
            return usersFromBase.FirstOrDefault(obj => obj.Login == user.Login) != null;
        }
    }
}
