using System;
using wpf_ui.Mediators;
using wpf_ui.ViewModels;

namespace wpf_ui.Utils
{
    public class NavigationService<TViewModel>
        where TViewModel : BaseViewModel
    {
        private readonly NavigationMediator _navigationMediator;
        private readonly Func<TViewModel> _createVMToNavigateTo;
        public NavigationService(
            NavigationMediator navigationMediator, 
            Func<TViewModel> createVMToNavigateTo)
        {
            _navigationMediator = navigationMediator;
            _createVMToNavigateTo = createVMToNavigateTo;
        }

        public void Navigate()
        {
            _navigationMediator.CurrentVM = _createVMToNavigateTo();
        }
    }
}
