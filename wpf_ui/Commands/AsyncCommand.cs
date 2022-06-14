using System.Threading.Tasks;

namespace wpf_ui.Commands
{
    public abstract class AsyncCommand : BaseCommand
    {
        private bool _isExecuting;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            set 
            { 
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }


        public override async void Execute(object parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (System.Exception)
            {
            }
            finally
            {
                IsExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
