using System;
using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class DeleteFromCartCommand : AsyncCommand
    {
        private readonly ToyCartViewModel _toysCartVM;
        private readonly CartMediator _cartMediator;

        public DeleteFromCartCommand(
            ToyCartViewModel toysCartVM,
            CartMediator cartMediator)
        {
            _toysCartVM = toysCartVM;
            _cartMediator = cartMediator;
            _toysCartVM.PropertyChanged += OnViewModelPropChanged;
        }

        private void OnViewModelPropChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (
                e.PropertyName == nameof(ToyListViewModel.SelectedToy))
            {
                OnCanExecuteChanged();
            }
        }

        public async override Task ExecuteAsync(object parameter)
        {
            await _cartMediator.DeleteFromCart(new BuisnessLogic.Toy
            {
                Id = _toysCartVM.SelectedToy.Id,
                Description = _toysCartVM.SelectedToy.Description,
                Name = _toysCartVM.SelectedToy.Name,
                Price = _toysCartVM.SelectedToy.Price,
                Subject = _toysCartVM.SelectedToy.Subject
            });
            _toysCartVM.DeleteSelected();
        }

        public override bool CanExecute(object parameter)
        {
            return _toysCartVM.SelectedToy != null &&
                base.CanExecute(parameter);
        }
    }
}
