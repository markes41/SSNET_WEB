using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNET_DataModel.Models.Comercio
{
    public class Compras
    {
        public int Id { get; set; }
        public string Productos_Id { get; set; }
        public bool? Procesado { get; set; }
        public int? Comprador_Id { get; set; }
        public DateTime? Fecha_Compra { get; set; }
        public decimal? Precio { get; set; }
        public virtual Usuarios Comprador { get; set; }
    }
}
