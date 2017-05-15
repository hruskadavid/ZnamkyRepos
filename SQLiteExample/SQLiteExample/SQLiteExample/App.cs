using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SQLiteExample
{
    public class App : Application
    {
        public App()
        {

            MainPage = new ZnamkyPage();
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

        private static Database _database;

        public static Database Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("Znamky.db3"));
                }
                return _database;
            }
        }
    }
}
