using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Dependency;
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
            MessagingCenter.Subscribe<App>(this, "Sleep.", (sender) =>
            {
                DisplayAlert("Zzz...", "Redirection!", "uch");
                Application.Current.MainPage.Navigation.PopAsync();
                //                Application.Current.MainPage.Navigation.PushModalAsync(new DogsPage(), true);

            });
        }
        public DogEntryPage(DogFormViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            MessagingCenter.Subscribe<App>(this, "Sleep.", (sender) =>
            {
                DisplayAlert("Zzz...", "Redirection!", "uch");
                Application.Current.MainPage.Navigation.PopAsync();
                //                Application.Current.MainPage.Navigation.PushModalAsync(new DogsPage(), true);

            });
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var dog = (Dog)BindingContext;
            dog.Date = dog.Date.Add(dog.Time);
            dog.City = dog.City + " " + dog.District;
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