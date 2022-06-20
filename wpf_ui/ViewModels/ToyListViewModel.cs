using BuisnessLogic;
using System;
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

    public class ToyListViewModel : BaseViewModel
    {
        private readonly ToysListMediator _toysListMediator;

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
            _toyList.Clear();
            foreach (var item in toys)
            {
                _toyList.Add(new ToyViewModel
                {
                    Id = item.Id, 
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description,
                    Subject = item.Subject,
                });
            }
            OnPropertyChanged(nameof(ToyList));
        }

        public void DeleteSelectedToy()
        {
            _toyList.Remove(SelectedToy);
        }

        public ToyListViewModel(
            CartMediator cartMediator,
            ToysListMediator toysListMediator, 
            NavigationService<CreateToyViewModel> navigateToTheViewService,
            NavigationService<ToyCartViewModel> toyCartViewModel
            )
        {
            _toysListMediator = toysListMediator;
            LoadToys = new LoadToysCommand(this, toysListMediator);
            LoadCart = new LoadInCartToysCommand(cartMediator);
            AddToy = new NavigateCommand<CreateToyViewModel>(navigateToTheViewService);
            UpdateToy = new UpdateToyCommand(this, toysListMediator, cartMediator);
            DeleteToy = new DeleteToyCommand(this, toysListMediator, cartMediator);
            AddToCart = new AddToCartCommand(this, cartMediator);
            ShowCart = new NavigateCommand<ToyCartViewModel>(toyCartViewModel);
        }

        public static ToyListViewModel CreateWithLoadedListAndCart(
            CartMediator cartMediator, 
            ToysListMediator toysListMediator, 
            NavigationService<CreateToyViewModel> navigateToTheViewService, 
            NavigationService<ToyCartViewModel> toyCartViewModel)
        {
            var vm = new ToyListViewModel(cartMediator, toysListMediator, navigateToTheViewService, toyCartViewModel);
            vm.LoadCart.Execute(null);
            vm.LoadToys.Execute(null);
            return vm;
        }

        public ICommand AddToy { get; }
        public ICommand UpdateToy { get; }
        public ICommand DeleteToy { get; }
        public ICommand AddToCart { get; }
        public ICommand LoadToys { get; }
        public ICommand LoadCart { get; }
        public ICommand ShowCart { get; }
    }
}
