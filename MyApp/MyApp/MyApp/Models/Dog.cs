using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public ICommand SaveCommand { get; set; }
        public Dog()
        {
            Name = "name";
            SaveCommand = new Command(SaveData);
        }

        private void SaveData()
        {
            Page page = new Page();
            page.DisplayAlert("Inserted dog", Name + Race + Age, "OK");
        }



    }
}
