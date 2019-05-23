
using MyApp.Data;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }
        static DogDatabase database;
        private DateTime SleepStart;
        private readonly TimeSpan SleepMax = TimeSpan.FromSeconds(5);
        public static DogDatabase Database
        {
            get
            {
                if (database == null)
                {
                    //DEPENDENCY SERVICE
                    database = new DogDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dogs.db3"));
                }
                return database;
            }
        }
        public App()
        {
            
            InitializeComponent();

            //DEPENDENCY SERVICE
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new DogsPage());

            //Button pickPictureButton = new Button
            //{
            //    Text = "Pick Photo",
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand
            //};
            //stack.Children.Add(pickPictureButton);
            //MainPage = new DogForm();
            //MainPage = new MainPage();
        }



        protected override void OnStart()
        {
            MessagingCenter.Send<App>(this, "App started.");
        }

        protected override void OnSleep()
        {
            SleepStart = DateTime.Now;
        }

        protected override void OnResume()
        {
            if (DateTime.Now - SleepStart > SleepMax)
            {
                MessagingCenter.Send<App>(this, "Sleep.");
                
            }
        }
    }
}
