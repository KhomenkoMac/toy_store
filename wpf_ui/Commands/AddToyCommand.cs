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
    }

    //public class LoadToysCommand : AsyncCommandBase
    //{
    //    private ObservableCollection<ToyViewModel> _toyViewModels;

    //    public TheStore theStore { get; set; }

    //    public LoadToysCommand(ObservableCollection<ToyViewModel> toyViewModels)
    //    {
    //        _theStore = theStore;
    //        _toyViewModels = toyViewModels;
    //    }
    //    public override async Task ExcecuteAsync(object parameter)
    //    {
    //        _toyViewModels.Clear();
    //        var toysFromBase = await _theStore.GetAllToys();
    //        _toyViewModels = new ObservableCollection<ToyViewModel>(toysFromBase.Select(tfb => new ToyViewModel()
    //        {
    //            Id = tfb.Id,
    //            Name = tfb.Name,
    //            Description = tfb.Description,
    //            Price = tfb.Price,
    //            Subject = tfb.Subject,
    //        }));
    //    }
    //}
}
