using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNET_DataModel.Models
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        [Display(Name = "Usuario")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Email { get; set; }
        public int Rol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CodeVerification { get; set; }
        public string ProfilePicture { get; set; }
        [NotMapped]
        public virtual List<Productos> Productos_Carrito { get; set; }

    }

}
