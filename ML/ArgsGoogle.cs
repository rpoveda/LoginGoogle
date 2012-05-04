using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ML
{
    public static class ArgsGoogle
    {
        private static string Url_Authentication = StructUrlAuthentication.Url;
        private static string Url_Access = StructUrlAccess.Url;
        public static string Scope = StructScope.All;
        public static string State = "/profile";
        public static string Redirect_Uri = ConfigurationManager.AppSettings["redirect_uri"];
        public static string Response_Type = StructResponseType.ResponseToke;
        public static string Client_Id = ConfigurationManager.AppSettings["client_id"];
        public static string AccessToke;

        /// <summary>
        /// url_authentication mounted for authentication and autorization
        /// </summary>
        /// <returns>String</returns>
        public static string UrlAuthenticationComplete()
        {
            var url_complete = Url_Authentication;
            url_complete = url_complete.Replace("{{SCOPE}}", Scope);
            url_complete = url_complete.Replace("{{STATE}}", State);
            url_complete = url_complete.Replace("{{REDIRECT_URI}}", Redirect_Uri);
            url_complete = url_complete.Replace("{{RESPONSE_TYPE}}", Response_Type);
            url_complete = url_complete.Replace("{{CLIENT_ID}}", Client_Id);
            return url_complete;
        }

        /// <summary>
        /// url_access mounted for get users informations
        /// </summary>
        /// <returns></returns>
        public static string UrlAccessComplete()
        {
            var url_complete = Url_Access;
            url_complete = url_complete.Replace("{{ACCESS_TOKEN}}", AccessToke);
            return url_complete;
        }
    }

    /// <summary>
    /// Contains url for initial authentication
    /// </summary>
    public struct StructUrlAuthentication
    {
        public static string Url =
            "https://accounts.google.com/o/oauth2/auth?scope={{SCOPE}}" +
            "&state={{STATE}}&redirect_uri={{REDIRECT_URI}}&response_type={{RESPONSE_TYPE}}" +
            "&client_id={{CLIENT_ID}}";
    }

    /// <summary>
    /// Contains url for access information of user
    /// </summary>
    public struct StructUrlAccess
    {
        public static string Url =
            "https://www.googleapis.com/oauth2/v1/userinfo?access_token={{ACCESS_TOKEN}}";
    }

    /// <summary>
    /// Contains types of scope property
    /// </summary>
    public struct StructScope
    {
        public static string Profile = "https://www.googleapis.com/auth/userinfo.profile";
        public static string Email = "https://www.googleapis.com/auth/userinfo.email";
        public static string All = Profile + "+" + Email;
    }

    /// <summary>
    /// Contains response types of response_type property
    /// </summary>
    public struct StructResponseType
    {
        public static string ResponseToke = "token";
        public static string ResponseCode = "code";
    }
}
