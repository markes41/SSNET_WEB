

namespace SSNET_WEB_CORE.Controllers
{
    using SSNET_DataModel;
    using SSNET_DataModel.Manager;
    using SSNET_DataModel.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SSNET_WEB_CORE.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LoginController : Controller
    {
        private Usuarios_Manager mg = new Usuarios_Manager(ProxyCreationEnabled: false);
        private SessionHelper _session; 
        public LoginController(SessionHelper session)
        {
            _session = session;
        }
        public IActionResult Login()
        {
            if (_session.GetUsuario() != null) 
                return RedirectToAction("Index", "Main");
            else
                return View();
        }

        [HttpPost]
        public IActionResult Login(Usuarios User)
        {
            if (ModelState.IsValid)
            {
                var TempUser = mg.ValidUserLogin(User);
                if(TempUser != null)
                {
                    _session.SetUser(TempUser);
                    return RedirectToAction("Index", "Main");
                }
            }
            ModelState.AddModelError("", mg.ErrorMessage);
            return View();
        }
        
        public IActionResult RestorePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RestorePassword(Usuarios user)
        {
            return Ok(new { Status = true, Message = "La contraseña ha cambiado correctamente." });
        }

        public JsonResult ValidEmailCode(string Code)
        {

            return Json(new { Status = true });
        }
    }
}
