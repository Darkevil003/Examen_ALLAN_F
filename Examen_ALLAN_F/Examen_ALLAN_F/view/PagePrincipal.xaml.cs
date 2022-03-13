using Examen_ALLAN_F.Controller;
using Examen_ALLAN_F.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        private void Edit_Clicked(object sender, EventArgs e)
        {

        }

        private async void editar_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var cont = item.CommandParameter as Contacto;
            await Navigation.PushAsync(new PageContacto(cont));
        }

        private async void eli_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var cont = item.CommandParameter as Contacto;
            var result = await DisplayAlert("Delete", $"Delete{cont.Nombre} de la Base de datos", "YES", "NO");
            if (result)
            {
                await DataBase.Delregister(cont);
                ListaContactos.ItemsSource = await  DataBase.listregistrer();

            }
        }
    }
}