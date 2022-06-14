using BuisnessLogic.Enums;
using BuisnessLogic.utils;
using System.Collections.Generic;
using System.Windows.Input;
using wpf_ui.Commands;
using wpf_ui.Mediators;
using wpf_ui.Utils;

namespace wpf_ui.ViewModels
{
    public class CreateToyViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get 
            { 
                return _name;
            }
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private double _price;
        public double Price
        {
            get 
            { 
                return _price; 
            }
            set 
            { 
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public IEnumerable<Subject> Subjects { get; }

        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get
            {
                return _selectedSubject;
            }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }

        private string _description;
        public string Description
        {
            get 
            { 
                return _description; 
            }
            set 
            { 
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public CreateToyViewModel(
            ToysListMediator mediator, 
            NavigationService<ToyListViewModel> navigateToTheViewService)
        {
            AddToStore = new AddToyCommand(mediator, this, navigateToTheViewService);
            Cancel = new NavigateCommand<ToyListViewModel>(navigateToTheViewService);
            Subjects = EnumsFactory.CreateSubjectsEnumColleciton();
        }


        public ICommand AddToStore { get; }
        public ICommand Cancel { get; }
    }
}
