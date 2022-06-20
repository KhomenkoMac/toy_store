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
        private readonly CartMediator _cartMediator;

        public UpdateToyCommand(ToyListViewModel toyListVM, ToysListMediator mediator, CartMediator cartMediator)
        {
            _toyListVM = toyListVM;
            _mediator = mediator;
            toyListVM.PropertyChanged += ToyListVMPropChanged;
            _cartMediator = cartMediator;
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
            var newOne = new BuisnessLogic.Toy
            {
                Id = _toyListVM.SelectedToy.Id,
                Name = _toyListVM.SelectedToy.Name,
                Description = _toyListVM.SelectedToy.Description,
                Price = _toyListVM.SelectedToy.Price,
                Subject = _toyListVM.SelectedToy.Subject
            };

            await _mediator.Update(newOne);
            _cartMediator.InCartToys.Remove(newOne.Id);
            _cartMediator.InCartToys.Add(newOne.Id, newOne);

        }

        public override bool CanExecute(object parameter)
        {
            return _toyListVM.SelectedToy != null && base.CanExecute(parameter);
        }
    }
}
