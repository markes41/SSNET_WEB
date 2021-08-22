using SSNET_DataModel.Manager;
using SSNET_DataModel.Models;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSNET_WEB_CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSNET_WEB_CORE.Controllers
{
    public class MainController : Controller
    {
        #region Atributos Locales
        private Productos_Manager mg = new Productos_Manager();
        private readonly SessionHelper _session;
        private Usuarios User = new Usuarios();
        #endregion

        #region Constructor
        public MainController(SessionHelper session)
        {
            _session = session;
            User = _session.GetUsuario();
        }
        #endregion

        #region Vistas
        public IActionResult Index()
        {
            if(User != null)
            {
                var ListadoProductos = User.Productos_Carrito.Select(m => m.Id).ToList();
                var ListModel = mg.GetProductosList().Where(m => !ListadoProductos.Contains(m.Id)).ToList();
                if (ListModel.Count() > 0) return View(ListModel);
                else return View(mg.GetProductosList());
            }
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Carrito()
        {
            if (User != null) return View(User.Productos_Carrito);
            return RedirectToAction("Login", "Login");

        }
        #endregion

        #region Métodos Públicos
        [HttpPost]
        public JsonResult AgregarProductoToCarrito(int Id_Model)
        {
            decimal Total = 0m;
            if (User == null) RedirectToAction("Login", "Login");
            if(!User.Productos_Carrito.Where(m => m.Id == Id_Model).Any()) User.Productos_Carrito.Add(mg.GetProductosList(Id_Model).FirstOrDefault());
            else
            {
                var Cantidad_Total = User.Productos_Carrito.Where(m => m.Id == Id_Model).Select(m => m.Cantidad).FirstOrDefault() + 1;
                User.Productos_Carrito.Where(m => m.Id == Id_Model).ToList().ForEach(x => x.Cantidad = Cantidad_Total);
            }
            foreach (var item in User.Productos_Carrito)
                Total += item.Precio * item.Cantidad;
            _session.SetUser(User);
            return Json(new { Status = true, Total =  Total});

        }

        [HttpPost]
        public JsonResult RemoveProductoFromCarrito(int Id_Model)
        {
            decimal Total = 0m;
            if (User == null) RedirectToAction("Login", "Login");
            if (User.Productos_Carrito.Where(m => m.Id == Id_Model).Any())
            {
                var Cantidad_Actual = User.Productos_Carrito.Where(m => m.Id == Id_Model).Select(m => m.Cantidad).FirstOrDefault() - 1;
                if (Cantidad_Actual > 0)
                    User.Productos_Carrito.Where(m => m.Id == Id_Model).ToList().ForEach(x => x.Cantidad = Cantidad_Actual);
                else
                    User.Productos_Carrito = User.Productos_Carrito.Where(m => m.Id != Id_Model).ToList();
            }
            foreach (var item in User.Productos_Carrito)
                Total += item.Precio * item.Cantidad;
            _session.SetUser(User);
            return Json(new { Status = true, Total = Total});

        }

        public JsonResult DeleteFromCarrito(int Id_Model)
        {
            if (User == null) RedirectToAction("Login", "Login");
            User.Productos_Carrito = User.Productos_Carrito.Where(m => m.Id != Id_Model).ToList();
            _session.SetUser(User);
            return Json(new { Status = true });
        }

        
        #endregion
    }
}
