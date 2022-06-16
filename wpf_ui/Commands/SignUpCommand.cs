using System;
using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class SignUpCommand : AsyncCommand
    {
        private readonly AuthorizationViewModel _authorizationVM;
        private readonly AuthorizationMediator _authorizationMediator;

        public SignUpCommand(AuthorizationViewModel authorizationVM, AuthorizationMediator authorizationMediator)
        {
            _authorizationVM = authorizationVM;
            _authorizationMediator = authorizationMediator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _authorizationMediator.SignUp(_authorizationVM.Login, _authorizationVM.Password);
        }

        public override bool CanExecute(object parameter)
        {
            return _authorizationMediator.CurrentUser == null && base.CanExecute(parameter);
        }
    }
}
