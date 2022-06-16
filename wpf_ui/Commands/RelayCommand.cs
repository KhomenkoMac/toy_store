using System;
using System.Windows.Input;

namespace wpf_ui.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
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
