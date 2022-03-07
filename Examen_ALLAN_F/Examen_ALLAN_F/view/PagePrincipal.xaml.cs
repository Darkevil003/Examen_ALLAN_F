using Examen_ALLAN_F.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_ALLAN_F.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

       
        private async void nuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageContacto());
        }

        private void ListaContactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null)
            {
                Model.Contacto contacto = (Model.Contacto)e.CurrentSelection.FirstOrDefault();
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ListaContactos.ItemsSource = await DataBase.listregistrer();
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
           


            await DisplayAlert("Alerta", "Se Elimino", "ok");
        }
    }
}