﻿using BuisnessLogic.Enums;
using System.Collections.Generic;
using wpf_ui.utils;

namespace wpf_ui.ViewModels.Items
{
    public class ToyViewModel : BaseViewModel
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
        }
    }
}