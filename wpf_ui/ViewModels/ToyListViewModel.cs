using System.Collections.ObjectModel;
using wpf_ui.ViewModels.Items;

namespace wpf_ui.ViewModels
{
    public class ToyListViewModel : BaseViewModel
    {

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

        public ObservableCollection<ToyViewModel> ToyList { get; }

        public ToyListViewModel()
        {
            ToyList = new ObservableCollection<ToyViewModel>
            {
                new ToyViewModel
                {
                    Name = "Toy1Toy1Toy1Toy1Toy1Toy1Toy1Toy1Toy1Toy1Toy1",
                    Description = "qwerty1",
                    Price = 100.3,
                    Subject = BuisnessLogic.Enums.Subject.anime
                },
                new ToyViewModel
                {
                    Name = "Toy1",
                    Description = "qwerty1",
                    Price = 100.3,
                    Subject = BuisnessLogic.Enums.Subject.military
                },
                new ToyViewModel
                {
                    Name = "Toy1",
                    Description = "qwerty1",
                    Price = 100.3,
                    Subject = BuisnessLogic.Enums.Subject.educational
                },
                new ToyViewModel
                {
                    Name = "Toy1",
                    Description = "qwerty1",
                    Price = 100.3,
                    Subject = BuisnessLogic.Enums.Subject.horror
                },
            };
        }
    }
}
