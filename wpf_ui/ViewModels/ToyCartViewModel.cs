using BuisnessLogic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using wpf_ui.Commands;
using wpf_ui.Mediators;
using wpf_ui.Utils;
using wpf_ui.ViewModels.Items;

namespace wpf_ui.ViewModels
{
    public class ToyCartViewModel : BaseViewModel
    {
        private readonly NavigationService<ToyListViewModel> _navigateToViewService;
        private readonly CartMediator _cartMediator;

        public ToyCartViewModel(CartMediator cartMediator, NavigationService<ToyListViewModel> navigateToViewService)
        {
            _navigateToViewService = navigateToViewService;
            _cartMediator = cartMediator;
            LoadInCartToys = new LoadInCartToysCommand(cartMediator);
            DeleteFromCart = new DeleteFromCartCommand(this, cartMediator);
            BackToStore = new NavigateCommand<ToyListViewModel>(navigateToViewService);
        }

        private ToyViewModel _selectedToy;
        public ToyViewModel SelectedToy
        {
            get
            {
                return _selectedToy;
            }
            set
            {
                _selectedToy = value;
                OnPropertyChanged(nameof(SelectedToy));
            }
        }

        private ObservableCollection<ToyViewModel> _toyList = new();
        public IEnumerable<ToyViewModel> ToyList => _toyList;

        public void UpdateToys()
        {
            _cartMediator.InCartToys.ToList().ForEach(obj => _toyList.Add(new ToyViewModel()
            {
                Id = obj.Key,
                Name = obj.Value.Name,
                Description = obj.Value.Description,
                Price = obj.Value.Price,
                Subject = obj.Value.Subject,
            }));
        }

        public void DeleteSelected()
        {
            _toyList.Remove(_selectedToy);
        }

        public static ToyCartViewModel CreateWithLoadedList(
            CartMediator cartMediator, 
            NavigationService<ToyListViewModel> navigateToViewService)
        {
            var vm = new ToyCartViewModel(cartMediator,navigateToViewService);
            vm.UpdateToys();
            return vm;
        }

        public ICommand LoadInCartToys { get; set; }
        public ICommand DeleteFromCart { get; }
        public ICommand Equip { get; }
        public ICommand BackToStore { get; }
    }
}
