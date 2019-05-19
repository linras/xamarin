using MyApp.Dependency;
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
            MessagingCenter.Subscribe<App>(this, "App started.", (sender) =>
            {
                DisplayAlert("Alert", "Welcome, this is cool dog app", "OK");
            });
            //MessagingCenter.Subscribe<App>(this, "Session expired.", (sender) =>
            //{
            //    DisplayAlert("Alert", "You have been alerted", "OK");
            //});
            base.OnAppearing();
            var dogs = new List<Dog>();
            dogs = await App.Database.GetDogsAsync();
            
            //Sorting events by date
            dogs.OrderBy(d => d.Date);
            foreach (Dog d in dogs)
            {
                DateTime dt = d.Date.Add(d.Time);
                Console.WriteLine(dt.ToString() + " vs " + DateTime.Now.ToString());
                //deleting past events
                if (dt.CompareTo(DateTime.Now) < 0)
                {
                    await App.Database.DeleteDogAsync(d);
                }
            }
            
            listView.ItemsSource = dogs;
            //listView.ItemsSource = await App.Database.GetDogsAsync();

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
        async void OnAddPhotoButtonClicked(object sender, EventArgs e)
        {
            IPicturePicker ipp = DependencyService.Get<IPicturePicker>();
            Stream stream = await ipp.GetImageStreamAsync();
            if (stream != null)
            {
                //Image image = new Image
                //{
                //    Source = ImageSource.FromStream(() => stream),
                //    BackgroundColor = Color.Gray
                //};
                Image img = this.FindByName<Image>("doggoImage");
                img.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}