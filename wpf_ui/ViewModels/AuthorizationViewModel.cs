using System.Windows.Input;
using wpf_ui.Commands;
using wpf_ui.Mediators;
using wpf_ui.Utils;

namespace wpf_ui.ViewModels
{
    public class AuthorizationViewModel : BaseViewModel
    {
        private string _login;
        public string Login
        {
            get { return _login; }
            set 
            { 
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        
        private string _password;
        public string Password
        {
            get { return _password; }
            set 
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public AuthorizationViewModel(AuthorizationMediator authorizationMediator, NavigationService<ToyListViewModel> navigationService)
        {
            SignIn = new SignInCommand(this, authorizationMediator, navigationService);
            SignUp = new SignUpCommand(this, authorizationMediator);
        }

        public ICommand SignIn { get; set; }
        public ICommand SignUp { get; set; }
    }
}
