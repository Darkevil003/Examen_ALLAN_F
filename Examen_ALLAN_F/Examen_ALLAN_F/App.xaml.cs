using Examen_ALLAN_F.Controller;
using Examen_ALLAN_F.view;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_ALLAN_F
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DB.conexion(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EXAMEN.db3"));

            MainPage = new NavigationPage(new view.PagePrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
