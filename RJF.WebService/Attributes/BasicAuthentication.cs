using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using RJB.BLL.Models;
using RJB.BLL.Users.Contracts;

namespace RJF.WebService.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        public bool IsUser { get; set; }

        public BasicAuthenticationAttribute(bool isUser)
        {
            IsUser = isUser;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var authorizationCredentials = request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationCredentials))
            {
                var credentials = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authorizationCredentials)).Split(':');
                var parsedCredentials = new CurrentUserViewModel { Name = credentials[0], Password = credentials[1] };

                if (!string.IsNullOrEmpty(parsedCredentials.Name) && !string.IsNullOrEmpty(parsedCredentials.Password))
                {
                    if (IsUser)
                    {
                        var clientService = DependencyResolver.Current.GetService(typeof(IClientService)) as IClientService;

                        if (clientService.GetClientByUsername(parsedCredentials.Name).Password ==
                            parsedCredentials.Password)
                        {
                            return;
                        }
                    }
                    else
                    {
                        var companyService = DependencyResolver.Current.GetService(typeof(ICompanyService)) as ICompanyService;

                        if (companyService.GetCompanyByNameOrEmail(parsedCredentials.Name).Password ==
                            parsedCredentials.Password)
                        {
                            return;
                        }
                    }
                }
            }
            
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}