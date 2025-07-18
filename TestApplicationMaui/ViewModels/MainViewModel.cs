﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApplicationMaui.Helpers.Enum;
using TestApplicationMaui.Models;

namespace TestApplicationMaui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        private Person selectedPerson;
        public Person SelectedPerson         
        { 
            get
            {
                return selectedPerson;
            }
            set
            {
                if(selectedPerson != value)
                {
                    selectedPerson = value;
                    OnPropertyChanged(nameof(SelectedPerson));
                }
            }
        }  
        public ObservableCollection<Person> SelectedPeople { get; set; }


        public ObservableCollection<DaysOfWeekEnum> DaysOfWeek { get; set; }
        public ObservableCollection<DaysOfWeekEnum> SelectedDaysOfWeek { get; set; }

        private DaysOfWeekEnum selectedDayOfWeek;
        public DaysOfWeekEnum SelectedDayOfWeek
        {
            get
            {
                return selectedDayOfWeek;
            }
            set
            {
                if (selectedDayOfWeek != value)
                {
                    selectedDayOfWeek = value;  
                    OnPropertyChanged(nameof(SelectedDayOfWeek));   
                }
            }
        }

        private TimeSpan time;
        public TimeSpan Time
        {
            get
            {
                return time;
            }
            set
            {
                if(value != time)
                {
                    time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        public ObservableCollection<bool> Bools { get; set; }

        public MainViewModel()
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                strings.Add($"F you {i}");
            }

            People = new ObservableCollection<Person>()
            {
                new Person(){Name = "Tom", Age = 26, TestList = strings},
                new Person(){Name = "Natalie", Age = 20, TestList = strings},
                new Person(){Name = "Yukari", Age = 16, TestList = strings},
                new Person(){Name = "Mitsuru", Age = 19, TestList = strings}
            };

            SelectedPerson = People.ElementAt(2);

            SelectedPeople = new ObservableCollection<Person>();

            SelectedPeople.Add(People[0]);
            Time = TimeSpan.FromMilliseconds(10000);

            DaysOfWeek = new ObservableCollection<DaysOfWeekEnum>()
            {
                DaysOfWeekEnum.Monday,
                DaysOfWeekEnum.Tuesday,
                DaysOfWeekEnum.Wednesday,
                DaysOfWeekEnum.Thursday,
                DaysOfWeekEnum.Friday,
                DaysOfWeekEnum.Saturday,
                DaysOfWeekEnum.Sunday,
                DaysOfWeekEnum.TrollMehe
            };

            SelectedDaysOfWeek = new ObservableCollection<DaysOfWeekEnum>();
            //SelectedDaysOfWeek = new ObservableCollection<DaysOfWeekEnum>()
            //{ 
            //    DaysOfWeekEnum.Friday
            //};

            Error = "Error message !";

            TrailingIconCommand = new Command<object>(TrailingIconMethod);


            Bools = new ObservableCollection<bool>()
            {
                true,
                false
            };
        }

        private string error;
        public string Error 
        {
            get { return error; }
            set
            {
                if(error != value) 
                { 
                    error = value;
                    OnPropertyChanged(nameof(Error));   
                }
            }
        }


        private int selectedItemSegment;

        public int SelectedItemSegment 
        { 
            get
            {
                return selectedItemSegment;
            }
            set
            {
                if(selectedItemSegment != value)
                {
                    selectedItemSegment = value;
                    OnPropertyChanged(nameof(SelectedItemSegment));
                }
            }
        }

        public ICommand TrailingIconCommand { get; set; }
        private void TrailingIconMethod(object obj)
        {
            if(obj is Entry)
            {
                (obj as Entry).IsPassword = (obj as Entry).IsPassword ? false : true;
            }

            Console.WriteLine("TrailingIconMethod");
        }
    }
}
