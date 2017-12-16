using System.Web.Mvc;
using HttpClientExtenctions.Helpers;
using Rjb.WebApplication.Models;

namespace Rjb.WebApplication.Attributes
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpClientHelper.User = CurrentUser.User;
        }
    }
}