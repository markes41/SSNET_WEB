using SSNET_DataModel.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSNET_WEB_CORE.Models
{
    /// <summary>
    /// Clase para obtener y setear el usuario en sesión. Se debe instanciar un atributo global y setear su valor dentro del constructor de la clase.
    /// </summary>
    public class SessionHelper
    {
        private IHttpContextAccessor _contextAccessor;

        #region Constructor
        public SessionHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region Métodos Públicos
        public Usuarios GetUsuario()
        {
            return _contextAccessor.HttpContext.Session.Get<Usuarios>("UserSession");
        }

        public void SetUser(Usuarios User)
        {
            _contextAccessor.HttpContext.Session.Set<Usuarios>("UserSession", User);
        }

        public void RemoveUser()
        {
            _contextAccessor.HttpContext.Session.Remove("UserSession");
        }
        #endregion
    }
}

