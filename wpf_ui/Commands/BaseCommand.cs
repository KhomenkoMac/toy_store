using System;
using System.Windows.Input;

namespace wpf_ui.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public abstract void Execute(object parameter);
        public virtual bool CanExecute(object parameter) => true;

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
