using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Notes.Data;
namespace Notes
{
    public partial class App : Application
    {
        static NoteDataBase dataBase;
        public static NoteDataBase DataBase
        {
            get
            {
                if(dataBase == null)
                {
                    dataBase = new NoteDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "Notes.db3"));
                }
                return dataBase;
            }
        }
        
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new NotesPage());
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
