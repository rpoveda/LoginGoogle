using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using ML;
using System.Net;

namespace BL
{
    public static class AuthenticationGoogle
    {
        static JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

        /// <summary>
        /// Return only json of google
        /// </summary>
        /// <returns>(String)Json</returns>
        public static string ReturnJson()
        {
            StringBuilder sb = new StringBuilder();
            javaScriptSerializer.Serialize(Authentication(), sb);
            return sb.ToString();
        }

        /// <summary>
        /// Return only object manipulated of return google
        /// </summary>
        /// <returns>ObjGoogle</returns>
        public static ObjGoogle ReturnObject()
        {
            var obj = javaScriptSerializer.Deserialize<ObjGoogle>(Authentication());
            return obj;
        }

        /// <summary>
        /// execute return info user
        /// </summary>
        /// <returns>String</returns>
        private static string Authentication()
        {
            var url_access = ArgsGoogle.UrlAccessComplete();
            WebRequest request = WebRequest.Create(url_access);
            WebResponse response = request.GetResponse();
            var dados = new StreamReader(response.GetResponseStream()).ReadToEnd().ToString();
            return dados;
        }
    }
}
