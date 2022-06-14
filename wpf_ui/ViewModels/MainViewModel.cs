using wpf_ui.Mediators;

namespace wpf_ui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationMediator _navigationMediator;

        public MainViewModel(NavigationMediator navigationMediator)
        {
            _navigationMediator = navigationMediator;
            _navigationMediator.CurrentVmChanged += VMChangedHandler;
        }

        private void VMChangedHandler()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }

        public BaseViewModel CurrentVM => _navigationMediator.CurrentVM;
    }
}
