using BuisnessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_ui.Mediators;
using wpf_ui.ViewModels;

namespace wpf_ui.Commands
{
    public class LoadInCartToysCommand : AsyncCommand
    {
        private readonly ToysListMediator _toysListMediator;
        private readonly ToyCartViewModel _toyCartVM;

        public LoadInCartToysCommand(
            ToyCartViewModel toyCartVM, 
            ToysListMediator toysListMediator)
        {
            _toyCartVM = toyCartVM;
            _toysListMediator = toysListMediator;
        }

        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
