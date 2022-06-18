using BuisnessLogic;
using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.Utils;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class AddToyCommand : AsyncCommand
    {
        
        private readonly ToysListMediator _mediator;
        private readonly CreateToyViewModel _viewModel;
        private readonly NavigationService<ToyListViewModel> _toToyLisingNavigationService;

        public AddToyCommand(
            ToysListMediator mediator,
            CreateToyViewModel viewModel, 
            NavigationService<ToyListViewModel> toToyLisingNavigationService)
        {
            _mediator = mediator;
            _viewModel = viewModel;
            _toToyLisingNavigationService = toToyLisingNavigationService;
            _viewModel.PropertyChanged += ViewModelPropChanged;
        }

        private void ViewModelPropChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateToyViewModel.Name) || 
                e.PropertyName == nameof(CreateToyViewModel.Price) ||
                e.PropertyName == nameof(CreateToyViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _mediator.Add(new Toy
                {
                    Name = _viewModel.Name,
                    Description = _viewModel.Description,
                    Price = _viewModel.Price,
                    Subject = _viewModel.SelectedSubject,
                });
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                _toToyLisingNavigationService.Navigate();
            }

        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_viewModel.Name) &&
                    _viewModel.Price > 0 &&
                    !string.IsNullOrWhiteSpace(_viewModel.Description) &&
                    base.CanExecute(parameter);
        }
    }
}
