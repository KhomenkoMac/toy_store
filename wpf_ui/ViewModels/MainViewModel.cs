namespace wpf_ui.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private BaseViewModel _currentPage;
        public BaseViewModel CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
    }
}
