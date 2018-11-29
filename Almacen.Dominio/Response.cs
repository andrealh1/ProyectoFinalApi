using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Dominio
{
   
    public class Response
    {

       
        public bool EsPermitido { get; set; }

       public string Mensaje { get; set; }

    }
}
