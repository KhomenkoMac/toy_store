using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class AddToCartCommand : AsyncCommand
    {
        private readonly ToyListViewModel _toyListVM;
        private readonly CartMediator _cartMediator;

        public AddToCartCommand(ToyListViewModel toyListVM, CartMediator cartMediator)
        {
            _cartMediator = cartMediator;
            _toyListVM = toyListVM;
            _toyListVM.PropertyChanged += ToyListVMPropertyChanged;
        }

        private void ToyListVMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToyListViewModel.SelectedToy))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _cartMediator.AddToCart(new BuisnessLogic.Toy
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
            return _toyListVM.SelectedToy != null && 
                    !_cartMediator.InCartToys.ContainsKey(_toyListVM.SelectedToy.Id) && 
                    base.CanExecute(parameter);
        }
    }
}
