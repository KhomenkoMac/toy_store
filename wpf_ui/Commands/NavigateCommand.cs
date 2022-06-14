using wpf_ui.Utils;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class NavigateCommand<TViewModel> : BaseCommand where TViewModel : BaseViewModel
    {
        private readonly NavigationService<TViewModel> _navigateToTheViewService;

        public NavigateCommand(NavigationService<TViewModel> navigateToTheViewService)
        {
            _navigateToTheViewService = navigateToTheViewService;
        }

        public override void Execute(object parameter)
        {
            _navigateToTheViewService.Navigate();
        }
    }
}
