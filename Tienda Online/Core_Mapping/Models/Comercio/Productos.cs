using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNET_DataModel.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Cantidad { get; set; }
        public string Moneda { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
