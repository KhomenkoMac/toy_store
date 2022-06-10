using BuisnessLogic;
using System;
using wpf_ui.ViewModels.Items;

namespace wpf_ui.Commands
{

    public class AddToyCommand : BaseCommand
    {
        private readonly TheStore _theStore;
        private readonly ToyViewModel _toyViewModel;

        public AddToyCommand(TheStore theStore, ToyViewModel toyViewModel)
        {
            _theStore = theStore;
            _toyViewModel = toyViewModel;
        }
        public override void Execute(object parameter)
        {
            
        }
    }
}
