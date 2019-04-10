using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyApp.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }
        static DogDatabase database;
        public static DogDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DogDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dogs.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();


            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new DogsPage());
            //MainPage = new DogForm();
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
