using BuisnessLogic;
using System.Threading.Tasks;
using wpf_ui.Utils;
using wpf_ui.ViewModels;

namespace wpf_ui.Mediators
{
    public class AuthorizationMediator
    {
        private readonly NavigationService<ToyListViewModel> _toViewNavigationService;
        private readonly TheAuthentication _theAuthentication;
        
        private Profile _currentUser;
        public Profile CurrentUser => _currentUser;

        public AuthorizationMediator(
            NavigationService<ToyListViewModel> toViewNavigationService, 
            TheAuthentication theAuthentication)
        {
            _toViewNavigationService = toViewNavigationService;
            _theAuthentication = theAuthentication;
        }

        public async Task SignIn(string login, string password)
        {
            var signedInUser = await _theAuthentication.SignIn(new User() { Login = login, Password = password });
            _currentUser = new Profile(signedInUser) ?? null;
        }

        public async Task SignUp(string login, string password)
        {
            await _theAuthentication.SignUp(new User
            {
                Login = login,
                Password = password
            });
        }
    }
}
