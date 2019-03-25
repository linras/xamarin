using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp
{
    public class DogFormViewModel
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public ICommand SaveCommand { get; set; }
        public DogFormViewModel()
        {
            Name = "default";
            SaveCommand = new Command(SaveData);
        }

        private void SaveData()
        {
            Page page = new Page();
            page.DisplayAlert("Inserted dog", Name + Race + Age, "OK");
        }



    }
}
