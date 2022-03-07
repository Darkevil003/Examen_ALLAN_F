using Examen_ALLAN_F.Controller;
using Examen_ALLAN_F.Model;
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
    public partial class PageContacto : ContentPage
    {
        public PageContacto()
        {
            InitializeComponent();
        }

        private void Btnagregar_Clicked(object sender, EventArgs e)
        {

        }

        private void Btnagregar_Clicked_1(object sender, EventArgs e)
        {
            
            
                var contacto = new Contacto()
                {
                    Nombre = nombre.Text,
                    Apellido = apellido.Text,
                    Edad = Convert.ToInt32(edad.Text),
                    Latitud = Convert.ToDouble(latitud.Text),
                    Longitud = Convert.ToDouble(longitud.Text),
                    Pais = pais.SelectedItem.ToString(),
                    Nota = nota.Text



                };
                DataBase.addregistrer(contacto);
           
           



           
        }

        private void Btneliminar_Clicked(object sender, EventArgs e)
        {
           

        }
    }
}