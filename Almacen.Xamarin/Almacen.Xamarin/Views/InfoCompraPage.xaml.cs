using Almacen.Dominio;
using Almacen.Xamarin.Resources;
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
	public partial class InfoCompraPage : ContentPage
	{
		public InfoCompraPage (Producto producto, int cantidad )
		{
			InitializeComponent ();
            BindingContext = producto;
            Cantidad.Text= cantidad.ToString();
            TotalPagar.Text = (cantidad * producto.Precio).ToString();
            
        }

               
       

        private async void Finalizar_Click(object sender, EventArgs e)
        {
            await DisplayAlert(AppResources.Felicitaciones, AppResources.Exitosa, "OK");

            

        }






    }
}