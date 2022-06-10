using BuisnessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

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

        private IEnumerable<Subject> _subjects = Enum.GetValues(typeof(Subject)).Cast<Subject>();
        public IEnumerable<Subject> Subjects
        {
            get 
            { 
                return _subjects; 
            }
            set 
            { 
                _subjects = value;
                OnPropertyChanged(nameof(Subjects));
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

        public CreateToyViewModel(ICommand addToStore, ICommand cancel)
        {
            AddToStore = addToStore;
            Cancel = cancel;
        }


        public ICommand AddToStore { get; }
        public ICommand Cancel { get; }
    }
}
