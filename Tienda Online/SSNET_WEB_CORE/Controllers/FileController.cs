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
        public IWebHostEnvironment _webHostEnvironment;
        public Usuarios_Manager mg = new Usuarios_Manager(ProxyCreationEnabled: false);
        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public void UploadProfilePicture([FromForm] FileUpload FileModel)
        {
            try
            {
                var User = HttpContext.Session.Get<Usuarios>("UserSession");
                User.ProfilePicture = ConvertImageToBase64(FileModel);
                mg.Save(User);
            }catch(Exception ex)
            {
            }
        }

        public string ConvertImageToBase64(FileUpload FileModel)
        {
            try
            {
                if (FileModel.File.Length > 0)
                {
                    var ms = new MemoryStream();
                    FileModel.File.CopyTo(ms);
                    var fileByte = ms.ToArray();
                    return Convert.ToBase64String(fileByte);
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public class FileUpload
        {
            public IFormFile File { get; set; }
        }
    }
}
