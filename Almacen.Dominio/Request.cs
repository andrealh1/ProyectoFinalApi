using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Dominio
{
   
        [Table("Request")]
        public class Request
        {
            // [Key]
            //public int Id { get; set; }

            [Key]
            [Required]
            public string Usuario { get; set; }

            [MaxLength(50)]
            [Required]
            public string Password { get; set; }
        }

    }

