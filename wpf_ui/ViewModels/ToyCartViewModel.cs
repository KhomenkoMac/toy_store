using BuisnessLogic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ToyCartViewModel(
            ToysListMediator toysListMediator, 
            NavigationService<ToyListViewModel> navigateToViewService)
        {
            _navigateToViewService = navigateToViewService;
            LoadInCartToys = new LoadInCartToysCommand(this, toysListMediator);
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

        public void UpdateToys(ICollection<Toy> toys)
        {
            foreach (var item in toys)
            {
                _toyList.Add(new ToyViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Subject = item.Subject,
                });
            }
        }

        public static ToyCartViewModel CreateWithLoadedList(
            ToysListMediator toysListMediator, 
            NavigationService<ToyListViewModel> navigateToViewService)
        {
            var vm = new ToyCartViewModel(toysListMediator, navigateToViewService);
            vm.LoadInCartToys.Execute(null);
            return vm;
        }

        public ICommand LoadInCartToys { get; }
        public ICommand DeleteFromCart { get; }
        public ICommand Equip { get; }
        public ICommand BackToStore { get; }
    }
}
