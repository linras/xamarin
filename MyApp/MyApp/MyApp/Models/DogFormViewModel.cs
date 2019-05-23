using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MyApp.Models
{
    public class DogFormViewModel : BaseViewModel
    {
        private int id;
        public int Id {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        private string district;
        public string District
        {
            get { return district; }
            set
            {
                district = value;
                OnPropertyChanged("District");
            }
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value.CompareTo(DateTime.Now) >= 0)
                    date = value;
                else date = DateTime.Now;
                OnPropertyChanged("Date");
            }
        } //= DateTime.Now;
        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
        public Command SaveDog
        {
            get
            {
                return new Command(async () =>
                {
                    if (Regex.IsMatch(name, "^[A-Z][a-z]{2,20}$"))
                    {
                        var dog = new Dog
                        {
                            ID = Id,
                            Name = Name,
                            Description = Description,
                            City = City + " " + District,
                            Password = Password,
                            Date = Date.Add(Time)
                        };
                        await App.Database.SaveDogAsync(dog);
                        await Application.Current.MainPage.Navigation.PopToRootAsync();
                    }
                    else await Application.Current.MainPage.DisplayAlert("Nope", "Wrong data", "Uch");

                });
            }
        }
        public Command Back
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PopToRootAsync();

                });
            }
        }
    }
}
