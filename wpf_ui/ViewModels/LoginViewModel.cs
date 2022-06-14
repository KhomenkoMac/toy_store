using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_ui.Commands;

namespace wpf_ui.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _login;

        public string Login
        {
            get 
            { 
                return _login; 
            }
            set 
            { 
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;

        public string Password
        {
            get 
            { 
                return _password; 
            }
            set 
            { 
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        ICommand ExecuteLogin { get; }

        public LoginViewModel()
        {
            ExecuteLogin = new АuthorizationCommand();
        }
    }
}
