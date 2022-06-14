using System;
using wpf_ui.ViewModels;

namespace wpf_ui.Mediators
{
    public class NavigationMediator
    {
        private BaseViewModel _currentVM;
        public BaseViewModel CurrentVM
        {
            get 
            { 
                return _currentVM; 
            }
            set 
            { 
                _currentVM = value;
                TriggerVMChanged();
            }
        }

        public event Action CurrentVmChanged;
        public void TriggerVMChanged()
        {
            CurrentVmChanged?.Invoke();
        }

    }
}
