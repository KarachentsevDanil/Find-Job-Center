using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Newtonsoft.Json;
using RJB.BLL.Models;
using RJB.BLL.Users.Contracts;

namespace RJF.WebService.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public bool IsUser { get; set; }

        public BasicAuthenticationAttribute(bool isUser)
        {
            IsUser = isUser;
        }

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            var request = filterContext.Request;
            var authorizationCredentials = request.Headers.Authorization.Parameter;

            if (!string.IsNullOrEmpty(authorizationCredentials))
            {
                var credentials = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authorizationCredentials)).Split(':');
                var parsedCredentials = new CurrentUserViewModel { Name = credentials[0], Password = credentials[1] };

                if (!string.IsNullOrEmpty(parsedCredentials.Name) && !string.IsNullOrEmpty(parsedCredentials.Password))
                {
                    if (IsUser)
                    {
                        var clientService = DependencyResolver.Current.GetService(typeof(IClientService)) as IClientService;
                        var client = clientService.GetClientByUsername(parsedCredentials.Name);

                        if (client.Password == parsedCredentials.Password)
                        {
                            return;
                        }
                    }
                    else
                    {
                        var companyService = DependencyResolver.Current.GetService(typeof(ICompanyService)) as ICompanyService;
                        var company = companyService.GetCompanyByNameOrEmail(parsedCredentials.Name);

                        if (company.Password == parsedCredentials.Password)
                        {
                            return;
                        }
                    }
                }
            }
            
            filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}