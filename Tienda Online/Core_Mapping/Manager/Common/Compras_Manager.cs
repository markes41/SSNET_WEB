using SSNET_DataModel.Models.Comercio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNET_DataModel.Manager.Common
{
    public class Compras_Manager : Base_Manager<Compras>
    {
        public Compras_Manager(bool ProxyCreationEnabled = true)
            : base(ProxyCreationEnabled: ProxyCreationEnabled)
        {
        }

        public Compras GetCompraById(int Id = 0)
        {
            return this.context.Compras.Where(m =>
                (m.Id == Id || Id == 0)).FirstOrDefault();
        }
    }
}
