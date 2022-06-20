using BuisnessLogic;
using System;
using System.Threading.Tasks;
using wpf_ui.Mediators;

namespace wpf_ui.Commands
{
    public class LoadInCartToysCommand : AsyncCommand
    {
        private readonly CartMediator _mediator;

        public LoadInCartToysCommand(CartMediator mediator)
        {
            _mediator = mediator;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            await _mediator.Load();
        }
    }
}
