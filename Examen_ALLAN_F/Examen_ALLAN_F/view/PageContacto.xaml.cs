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
    public partial class PageContacto : ContentPage
    {
        Contacto _contacto;
        public PageContacto()
        {
            InitializeComponent();
        }
        public PageContacto(Contacto contacto)
        {
            InitializeComponent();
            Title = "Editar";
            _contacto = contacto;
            nombre.Text = contacto.Nombre;
            apellido.Text = contacto.Apellido;
            edad.Text = contacto.Edad.ToString();
            latitud.Text = contacto.Latitud.ToString();
            longitud.Text = contacto.Longitud.ToString();
            pais.SelectedItem = contacto.Pais;
            telefono.Text = contacto.Telefono.ToString();
            nota.Text = contacto.Nota;




        }

        private void Btnagregar_Clicked(object sender, EventArgs e)
        {

        }
         protected async override void OnAppearing()
        {
            base.OnAppearing();
            CancellationTokenSource cts;
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    latitud.Text = Convert.ToString(location.Latitude);
                    longitud.Text = Convert.ToString(location.Longitude);
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    location = await Geolocation.GetLocationAsync(request, cts.Token);

                    if (location != null)
                    {
                        latitud.Text =Convert.ToString(location.Latitude);
                        longitud.Text = Convert.ToString(location.Longitude);
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                fnsEx.ToString();
            }
        }


        private async void Btnagregar_Clicked_1(object sender, EventArgs e)
        {
           

            if (string.IsNullOrWhiteSpace(nombre.Text) || string.IsNullOrWhiteSpace(apellido.Text) ||

                string.IsNullOrWhiteSpace(edad.Text)|| string.IsNullOrWhiteSpace(telefono.Text) ||
                string.IsNullOrWhiteSpace(nota.Text) || string.IsNullOrWhiteSpace(pais.SelectedItem.ToString()))
            {
                await DisplayAlert("Alerta", "CAMPO EN BLANCO RELLENE TODOS LOS CAMPOS REQUERIDOS", "OK");

            }else if (_contacto !=null)
            {



                _contacto.Nombre = nombre.Text;
                _contacto.Apellido = apellido.Text;
                _contacto.Edad = Convert.ToInt32(edad.Text);
                _contacto.Latitud = Convert.ToDouble(latitud.Text);
                _contacto.Longitud = Convert.ToDouble(longitud.Text);
                _contacto.Pais = pais.SelectedItem.ToString();
                _contacto.Telefono = Convert.ToDouble(telefono.Text.ToString());
                _contacto.Nota = nota.Text;



                
                await DataBase.Actualizar(_contacto);
                await Navigation.PopToRootAsync();

            }
            else
            {
                
                var contacto = new Contacto()
                {
                    Nombre = nombre.Text,
                    Apellido = apellido.Text,
                    Edad = Convert.ToInt32(edad.Text),
                    Latitud = Convert.ToDouble(latitud.Text),
                    Longitud = Convert.ToDouble(longitud.Text),

                    Pais = pais.SelectedItem.ToString(),
                    Telefono= Convert.ToDouble(telefono.Text),
                    Nota = nota.Text



                };
               await  DataBase.addregistrer(contacto);
               await Navigation.PopToRootAsync();
            }

         






        }

        private void Btneliminar_Clicked(object sender, EventArgs e)
        {
           

        }
    }
}