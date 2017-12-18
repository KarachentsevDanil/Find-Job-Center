using System;
using System.Web;
using Newtonsoft.Json;
using RJB.BLL.Models;

namespace Rjb.WebApplication.Models
{
    public static class CurrentUser
    {
        private const string CookiePathName = "userInfo";

        public static CurrentUserViewModel User
        {
            get
            {
                var userCookie = HttpContext.Current.Request.Cookies[CookiePathName];

                if (!string.IsNullOrEmpty(userCookie?.Value))
                {
                    var user = JsonConvert.DeserializeObject<CurrentUserViewModel>(userCookie.Value);
                    return user;
                }

                return null;
            }
            set
            {
                var userInfo = JsonConvert.SerializeObject(value);

                if (string.IsNullOrEmpty(userInfo))
                {
                    return;
                }

                var cookie = new HttpCookie(CookiePathName)
                {
                    Expires = DateTime.MinValue, 
                    Value = userInfo
                };

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}