using System;
using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class UpdateToyCommand : AsyncCommand
    {
        private readonly ToyListViewModel _toyListVM;
        private readonly ToysListMediator _mediator;

        public UpdateToyCommand(ToyListViewModel toyListVM, ToysListMediator mediator)
        {
            _toyListVM = toyListVM;
            _mediator = mediator;
            toyListVM.PropertyChanged += ToyListVMPropChanged;
        }

        private void ToyListVMPropChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToyListViewModel.SelectedToy))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _mediator.Update(new BuisnessLogic.Toy
            {
                Id = _toyListVM.SelectedToy.Id,
                Name = _toyListVM.SelectedToy.Name,
                Description = _toyListVM.SelectedToy.Description,
                Price = _toyListVM.SelectedToy.Price,
                Subject = _toyListVM.SelectedToy.Subject
            });
        }

        public override bool CanExecute(object parameter)
        {
            return _toyListVM.SelectedToy != null && base.CanExecute(parameter);
        }
    }
}
