using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ingenio.WebClient.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Contraseña { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
    }
}