using Almacen.Dominio;
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
	public partial class ProductosPage : ContentPage
	{
		public ProductosPage ()
		{
			InitializeComponent ();
            CargarProductos();
        }

        private async void CargarProductos()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.43.5");

            var request = await client.GetAsync("/ApisAlmacen/api/Producto");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var listado = JsonConvert.DeserializeObject<List<Producto>>(responseJson);
                listProductos.ItemsSource = listado;
            }
            else
            {
                await DisplayAlert("Lo sentimos!", "Ha ocurrido un error de comunicacion", "OK");
            }
        }



        private async void Producto_Selected(object sender, SelectedItemChangedEventArgs e)
       {
            var producto = (Producto)e.SelectedItem;
            await Navigation.PushAsync(new DetalleProductoPage(producto));
       }







    }
}