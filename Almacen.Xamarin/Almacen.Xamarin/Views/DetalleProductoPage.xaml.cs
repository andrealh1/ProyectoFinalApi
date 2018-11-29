using Almacen.Dominio;
using Almacen.Xamarin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Almacen.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalleProductoPage : ContentPage
	{
        private Producto producto;

        public DetalleProductoPage (Producto producto)
		{
			InitializeComponent ();
            this.producto = producto;
            BindingContext = producto;
            
        }
        

        


       

        private async void Finalizar_Click(object sender, EventArgs e)
        {
                string cantidad = CantidadComprar.Text;
               

               if (string.IsNullOrEmpty(cantidad))
                {
                    await DisplayAlert(AppResources.Validacion, AppResources.IngreseCantidad, "OK");
                    return;
                }
          

                                        


            int cant = Convert.ToInt32(cantidad);

            if (cant>producto.Cantidad)
            {
                await DisplayAlert(AppResources.Validacion, AppResources.MenorAStock, "OK");
                return;
            }
           



            await Navigation.PushAsync(new InfoCompraPage(producto, cant));
        }
               

    }
}