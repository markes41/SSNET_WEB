using SSNET_DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNET_DataModel.Manager
{
    public class Usuarios_Manager : Base_Manager<Usuarios>
    {
        
        public string ErrorMessage { get; set; }
        public Usuarios_Manager(bool ProxyCreationEnabled = true) 
            : base (ProxyCreationEnabled: ProxyCreationEnabled)
        {
        }

        public bool Save(Usuarios User)
        {
            try
            {
                if(User.Id == 0)
                    User.Password = Base64Encode(User.Password);
                return Save(User, User.Id == 0);
                
            }catch(Exception ex)
            {
                return false;
            }
        }

        public Usuarios ValidUserLogin(Usuarios User)
        {
            try
            {
                var TempUser = context.Usuarios.Where(m => m.Username == User.Username).FirstOrDefault();
                if (TempUser != null)
                {
                    if (Base64Decode(TempUser.Password) == User.Password)
                        return TempUser;
                    else
                        ErrorMessage = "La contraseña introducida es incorrecta.";
                }
                else
                    ErrorMessage = "No hemos encontrado el usuario en nuestros registros. Intente con otras credenciales.";
                return null;
            }catch(Exception ex)
            {
                return null;
            }
        }

    }
}
