using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DogEntryPage : ContentPage
	{
		public DogEntryPage ()
		{
			InitializeComponent ();
		}
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var dog = (Dog)BindingContext;

            //dog.Name = "Piszczel";
            await App.Database.SaveDogAsync(dog);
            //if (string.IsNullOrWhiteSpace(dog.Filename))
            //{
            //    // Save
            //    //var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.dogs.txt");
            //    var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.dogs.txt");
            //    File.WriteAllText(filename, dog.Description);
            //}
            //else
            //{
            //    // Update
            //    File.WriteAllText(dog.Filename, dog.Description);
            //}

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var dog = (Dog)BindingContext;

            await App.Database.DeleteDogAsync(dog);
            //if (File.Exists(dog.Filename))
            //{
            //    File.Delete(dog.Filename);
            //}

            await Navigation.PopAsync();
        }
    }
}