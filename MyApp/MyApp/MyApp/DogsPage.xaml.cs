using MyApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DogsPage : ContentPage
	{
		public DogsPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetDogsAsync();
            //var dogs = new List<Dog>();

            //var files = Directory.EnumerateFiles(App.FolderPath, "*.dogs.txt");
            //foreach (var filename in files)
            //{
            //    dogs.Add(new Dog
            //    {
            //        Filename = filename,
            //        Description = File.ReadAllText(filename),
            //        Name = "Burek"
            //    });
            //}

            //listView.ItemsSource = dogs
            //    .OrderBy(d => d.Name)
            //    .ToList();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DogEntryPage
            {
                BindingContext = new Dog()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DogEntryPage
                {
                    BindingContext = e.SelectedItem as Dog
                });
            }
        }
    }
}