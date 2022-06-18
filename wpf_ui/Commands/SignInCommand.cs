using System.Diagnostics;
using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.Utils;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class SignInCommand : AsyncCommand
    {
        private readonly AuthorizationViewModel _authorizationVM;
        private readonly AuthorizationMediator _authorizationMediator;
        private readonly NavigateCommand<ToyListViewModel> _navigateCommand;

        public SignInCommand(
            AuthorizationViewModel authorizationVM, 
            AuthorizationMediator authorizationMediator,
            NavigationService<ToyListViewModel> navigationService)
        {
            _authorizationVM = authorizationVM;
            _authorizationMediator = authorizationMediator;
            _navigateCommand = new NavigateCommand<ToyListViewModel>(navigationService);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _authorizationMediator.SignIn(_authorizationVM.Login, _authorizationVM.Password);
            if (_authorizationMediator.CurrentUser != null)
            {
                _navigateCommand.Execute(null);
                Debug.WriteLine("Signed in!!!", "Sign In");
            }
        }
    }
}
