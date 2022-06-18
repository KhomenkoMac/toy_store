using System;
using System.Linq;
using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class DeleteToyCommand : AsyncCommand
    {
        private readonly ToysListMediator _mediator;
        private readonly ToyListViewModel _viewModel;

        public DeleteToyCommand(ToyListViewModel viewModel, ToysListMediator mediator)
        {
            _viewModel = viewModel;
            _mediator = mediator;
            _viewModel.PropertyChanged += OnViewModelPropChanged;
        }

        private void OnViewModelPropChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToyListViewModel.ToyList) || 
                e.PropertyName == nameof(ToyListViewModel.SelectedToy))
            {
                OnCanExecuteChanged();
            }
        }

        public async override Task ExecuteAsync(object parameter)
        {
            await _mediator.Delete(new BuisnessLogic.Toy
            {
                Id = _viewModel.SelectedToy.Id,
                Name = _viewModel.SelectedToy.Name,
                Description = _viewModel.SelectedToy.Description,
                Price = _viewModel.SelectedToy.Price,
                Subject = _viewModel.SelectedToy.Subject
            });
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedToy != null &&
                   _viewModel.ToyList.Any() &&
                   base.CanExecute(parameter);
        }
    }
}
