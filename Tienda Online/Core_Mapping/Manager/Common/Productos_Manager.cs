using SSNET_DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNET_DataModel.Manager
{
    public class Productos_Manager : Base_Manager<Productos>
    {
        public string ErrorMessage { get; set; }
        public Productos_Manager(bool ProxyCreationEnabled = true) 
            : base(ProxyCreationEnabled: ProxyCreationEnabled)
        {
        }

        public List<Productos> GetProductosList(int Id = 0, string Titulo = "")
        {
            return this.context.Productos.Where(m =>
                (m.Id == Id || Id == 0)
                && ((Titulo != null && m.Titulo.Contains(Titulo)) || Titulo == null)).ToList();
        }
    }
}

