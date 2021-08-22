using SSNET_DataModel.Models;
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
        public Usuarios User = new Usuarios();
        public Compras_Manager(bool ProxyCreationEnabled = true, int Id_Usuario = -1, int Id_Compra = -1)
            : base(ProxyCreationEnabled: ProxyCreationEnabled)
        {
            if(Id_Usuario >= 0) User = this.context.Usuarios.Where(m => m.Id == Id_Usuario).FirstOrDefault();
            if (Id_Compra >= 0) this._EntityModel = this.context.Compras.Where(m => m.Id == Id_Usuario).FirstOrDefault();
        }

        public bool Save(Compras Compra_Realizada)
        {
            return true;
        }
    }
}
