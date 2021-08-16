using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.Json;

namespace SSNET_WEB_CORE.Models
{
    public static class SessionExtensions
    {

        public static void Set<Usuarios>(this ISession session, string key, SSNET_DataModel.Models.Usuarios User)
        {
            if (User.Productos_Carrito == null) User.Productos_Carrito = new List<SSNET_DataModel.Models.Productos>();
            session.SetString(key, JsonSerializer.Serialize(User));
        }

        public static Usuarios Get<Usuarios>(this ISession session, string key)
        {
            var value = session.GetString(key);
            //var test = JsonSerializer.Deserialize<Usuarios>(value);
            return value == null ? default : JsonSerializer.Deserialize<Usuarios>(value);
        }
    }

}
