using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{

    public class LoadToysCommand : AsyncCommand
    {
        private readonly ToysListMediator _mediator;
        private readonly ToyListViewModel _viewModel;
        public LoadToysCommand(ToysListMediator mediator, ToyListViewModel viewModel)
        {
            _mediator = mediator;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _mediator.Load();
                _viewModel.UpdateToys(_mediator.Toys);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
