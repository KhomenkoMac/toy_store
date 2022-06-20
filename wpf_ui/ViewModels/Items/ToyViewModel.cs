using BuisnessLogic.Enums;
using BuisnessLogic.utils;
using System.Collections.Generic;
using System.Windows.Input;
using wpf_ui.Commands;

namespace wpf_ui.ViewModels.Items
{
    public class ToyViewModel : BaseViewModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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
        
        public IEnumerable<Subject> Subjects { get; }

        private Subject _subj;
        public Subject Subject
        {
            get
            {
                return _subj;
            }
            set
            {
                _subj = value;
                OnPropertyChanged(nameof(Subject));
            }
        }

        public ToyViewModel()
        {
            Subjects = EnumsFactory.CreateSubjectsEnumColleciton();
            Click = new HelloCommand();
        }

        //public ToyViewModel(int id, string name, double price, string description, Subject subj, bool addedToCart)
        //{
        //    _id = id;
        //    _name = name;
        //    _price = price;
        //    _description = description;
        //    _subj = subj;
        //    _addedToCart = addedToCart;
        //    this();
        //}

        public ICommand Click { get; set; }
    }
}
