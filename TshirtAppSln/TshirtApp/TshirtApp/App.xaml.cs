using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtApp
{
    public partial class App : Application
    {
        private static TshirtDatabase tshirtdatabases;

        public static TshirtDatabase Database
        {
            get
            {
                if(tshirtdatabases == null)
                    tshirtdatabases = new TshirtDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tshirt.db3"));
                return tshirtdatabases;
            }
        }

        public int ResumeTshiirtApp { get; internal set; }

        public static object TshirtDatabases { get; set; }
        
        public App()
        {
            InitializeComponent();
            var nav = new NavigationPage(new MainPage());

            MainPage = nav;
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
