using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MVVMPattern.Model
{
    class User:INotifyPropertyChanged
    {
        private int userId;
        private string fristName;
        private string lastName;
        private string city;
        private string state;
        private string country;

        

        public int UserId
        {
            get => userId;
            set {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public string FirstName
        {
            get => fristName;
            set
            {
                fristName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged("City");

            }
        }


        public string State
        {
            get => state;
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string proprtyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proprtyName));
        }
    }


}
