using Almacen.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Almacen.Api.Models
{
    public class ProductoContext: DbContext
    {
        public ProductoContext(): base("ProductoConnection")
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Request> Requests { get; set; }
       
    }
}