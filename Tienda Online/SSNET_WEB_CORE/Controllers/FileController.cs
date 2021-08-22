using SSNET_DataModel.Manager;
using SSNET_DataModel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSNET_WEB_CORE.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SSNET_WEB_CORE.Controllers
{
    public class FileController : Controller
    {
        public Productos_Manager mg = new Productos_Manager(ProxyCreationEnabled: false);
        private readonly SessionHelper _session;
        private Usuarios User = new Usuarios();
        public FileController(SessionHelper session)
        {
            _session = session;
            User = _session.GetUsuario();
        }

        [HttpPost]
        public void UploadProduct(Productos Model)
        {
            try
            {
                Model.Imagen = mg.ConvertFileToBase64(Model.ImageToUpload);
                mg.Save(Model, Model.Id == 0);
            }catch(Exception ex)
            {
            }
        }
    }
}
