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
                _toyList.Add(new ToyViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Subject = item.Subject,
                });
            }
            OnPropertyChanged(nameof(ToyList));
        }

        public void OnDeleteToy(int toyId, ICollection<Toy> toys)
        {
            //var ts1 = toys.Select(obj => obj.Id);
            //var ts2 = _toyList.Select(obj => obj.Id);

            //var linked = new LinkedList<ToyViewModel>(_toysListMediator.Toys.ToList());
            //var foundVM = linked.FirstOrDefault(obj => obj.Id == toyId);
            //var foundNode = linked.Find(foundVM);
            //var s = foundNode.Previous?.Value;
            
            //linked.Remove(foundNode);
            //_toyList.Clear();

            //foreach (var item in linked)
            //{
            //    _toyList.Add(item);
            //}

            //SelectedToy = s;
        }

        public ToyListViewModel(
            ToysListMediator toysListMediator, 
            NavigationService<CreateToyViewModel> navigateToTheViewService)
        {
            _toysListMediator = toysListMediator;
            LoadToys = new LoadToysCommand(this, toysListMediator);
            AddToy = new NavigateCommand<CreateToyViewModel>(navigateToTheViewService);
            UpdateToy = new UpdateToyCommand(this, toysListMediator);
            DeleteToy = new DeleteToyCommand(this, toysListMediator);
            _toysListMediator.ToyListChanged += UpdateToys;
        }

        public static ToyListViewModel CreateWithLoadedList(ToysListMediator toysListMediator, NavigationService<CreateToyViewModel> navigateToTheViewService)
        {
            var vm = new ToyListViewModel(toysListMediator, navigateToTheViewService);
            vm.LoadToys.Execute(null);
            return vm;
        }

        public ICommand AddToy { get; }
        public ICommand UpdateToy { get; }
        public ICommand DeleteToy { get; }
        public ICommand AddToCart { get; }
        public ICommand LoadToys { get; }
    }
}
