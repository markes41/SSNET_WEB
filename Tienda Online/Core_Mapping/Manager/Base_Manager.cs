
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSNET_DataModel.Manager
{
    /// <summary>
    /// Clase principal de los manager, todos heredan de este. Tiene configuraciones básicas y el método Save principal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Base_Manager<T> where T : class
    {
        #region Attributes
        public readonly VisualContext context = new VisualContext();
        public T _EntityModel { get; set; }
        public List<T> _EntityModelList { get; set; }
        public virtual List<T> GetDatasources 
        {
            get
            {
                try
                {
                    return context.Set<T>().ToList();
                }
                catch (Exception ex)
                {

                    return null;
                }
            }
        }
        #endregion

        #region Constructor
        public Base_Manager(bool ProxyCreationEnabled = true)
        {
            context.Configuration.ProxyCreationEnabled = ProxyCreationEnabled;
        }
        #endregion

        #region Métodos
        public virtual bool Save<T>(T EntityModel, bool IsNew = true) where T : class, new()
        {
            try
            {
                if (IsNew)
                {
                    context.Entry<T>(EntityModel).State = EntityState.Added;
                }
                else
                {
                    context.Entry<T>(EntityModel).State = EntityState.Modified;

                }
                return context.SaveChanges() > 0;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public string ConvertFileToBase64(IFormFile FileModel)
        {
            try
            {
                if (FileModel.Length > 0)
                {
                    var ms = new MemoryStream();
                    FileModel.CopyTo(ms);
                    var fileByte = ms.ToArray();
                    return Convert.ToBase64String(fileByte);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Encrpyt/Desencrypt
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        #endregion
    }
}
