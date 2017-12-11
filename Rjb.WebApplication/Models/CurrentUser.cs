using System;
using System.Web;
using Newtonsoft.Json;
using RJB.BLL.Models;

namespace Rjb.WebApplication.Models
{
    public static class CurrentUser
    {
        public static CurrentUserViewModel User
        {
            get
            {
                var userCookie = HttpContext.Current.Request.Cookies["userInfo"];

                if (userCookie != null)
                {
                    return JsonConvert.DeserializeObject<CurrentUserViewModel>(userCookie.Value);
                }

                return null;
            }
            set
            {
                var userInfo = JsonConvert.SerializeObject(value);

                var cookie = new HttpCookie(userInfo)
                {
                    Expires = DateTime.MinValue, 
                    Name = "userInfo"
                };

                HttpContext.Current.Request.Cookies.Add(cookie);
            }
        }
    }
}