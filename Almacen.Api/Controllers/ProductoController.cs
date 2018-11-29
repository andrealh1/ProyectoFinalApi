using Almacen.Api.Models;
using Almacen.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Almacen.Api.Controllers
{
    public class ProductoController : ApiController
    {
        public IEnumerable<Producto> Get()
        {
            using (ProductoContext context = new ProductoContext())
            {
                var listado = context.Productos.ToList();

                //Actualizar la ruta de la imagen
                listado.ForEach(x => x.Imagen = Url.Content(x.Imagen));

                return listado;
            }

        }

        [HttpGet]
        public Producto Get(int id)
        {
            using (var context = new ProductoContext())
            {
                return context.Productos.FirstOrDefault(x => x.Id == id);
            }
        }
        [HttpPost]
        public IHttpActionResult Post(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new ProductoContext())
            {

                context.Productos.Add(producto);
                context.SaveChanges();
                return Ok(producto);
            }

        }
        [HttpPut]
        public bool Put(Producto producto)
        {
            using (var context = new ProductoContext())
            {
                var productoAct = context.Productos.FirstOrDefault(x => x.Id == producto.Id);
                productoAct.Referencia = producto.Referencia;
                productoAct.Nombre = producto.Nombre;
                productoAct.Descripcion = producto.Descripcion;
                productoAct.Cantidad = producto.Cantidad;
                productoAct.Precio = producto.Precio;
                productoAct.Imagen = producto.Imagen;
                return context.SaveChanges()>0;
                //return producto;
            }

        }
        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new ProductoContext())
            {
                var productoDel = context.Productos.FirstOrDefault(x => x.Id == id);
                context.Productos.Remove(productoDel);
                context.SaveChanges();
                return true;
            }


        }







    }
}
