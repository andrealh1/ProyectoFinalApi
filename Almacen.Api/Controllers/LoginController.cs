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
    public class LoginController : ApiController
    {

        public IEnumerable<Request> Get()
        {
            using (ProductoContext context = new ProductoContext())
            {
                return context.Requests.ToList();

            }
        }



        [HttpPost]
        public IHttpActionResult Autenticacion(Request peticion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = peticion.Usuario;
            var password = peticion.Password;

            using (var context = new ProductoContext())
            {
                var permitido = context.Requests.Any(x => x.Usuario == user && x.Password == password);
                var response = new Response();
                response.EsPermitido = permitido;

                if (permitido)
                {
                    response.Mensaje = "OK";

                }
                else
                {
                    response.Mensaje = "No se puede iniciar";

                }

                    return Ok(response);
            }

            

            

        }



    }
}
