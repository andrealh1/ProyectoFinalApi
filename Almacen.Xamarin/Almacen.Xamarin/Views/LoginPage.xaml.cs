using Almacen.Dominio;
using Almacen.Xamarin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Almacen.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Ingresar_Click(object sender, EventArgs e)
        {
            var usuario = Usuario.Text;
            var password = Password.Text;

            if (string.IsNullOrEmpty(usuario))
            {
                await DisplayAlert(AppResources.Validacion, AppResources.ValidacionUsuario , AppResources.Aceptar);
                Usuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert(AppResources.Validacion, AppResources.ValidacionContrasena, AppResources.Aceptar);
                Usuario.Focus();
                return;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.43.5");

            var autenticacion = new Request
            {
                Usuario = usuario,
                Password = password
            };

            string json = JsonConvert.SerializeObject(autenticacion);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync("/ApisAlmacen/api/Login", content);
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<Response>(responseJson);

                if (respuesta.EsPermitido)
                {

                    await DisplayAlert(AppResources.AccesoAutorizado, respuesta.Mensaje, AppResources.Iniciar);
                    await Navigation.PushAsync(new ProductosPage());
                    

                }
                else
                {
                    await DisplayAlert(AppResources.AccesoDenegado, respuesta.Mensaje, AppResources.Aceptar);
                    



                }
            }
            else
            {
                
                await DisplayAlert(AppResources.LoSentimos, AppResources.Error, AppResources.Aceptar);
            }




        }
    }
}