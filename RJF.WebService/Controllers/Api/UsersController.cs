using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FJB.Domain.Entities.Users;
using RJB.BLL.Models;
using RJB.BLL.Users.Contracts;
using RJF.WebService.Models;

namespace RJF.WebService.Controllers.Api
{
    public class UsersController : ApiController
    {
        private readonly IClientService _clientService;
        private readonly ICompanyService _companyService;

        public UsersController(IClientService clientService, ICompanyService companyService)
        {
            _clientService = clientService;
            _companyService = companyService;
        }

        [HttpPost]
        public HttpResponseMessage ClientLogin([FromBody] UserLoginModel loginModel)
        {
            try
            {
                var client = _clientService.GetClientByUsername(loginModel.UserName);

                if (loginModel.Password == client.Password)
                {
                    CurrentUser.User = new CurrentUserViewModel
                    {
                        Name = client.FullName,
                        IsClient = true,
                        Role = client.Role,
                        UserId = client.ClientId
                    };

                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage RegisterClient([FromBody] Client client)
        {
            try
            {
                if (!_clientService.IsClientExist(client))
                {
                    _clientService.AddClient(client);
                    return Request.CreateResponse(HttpStatusCode.Created);
                }

                return Request.CreateResponse(HttpStatusCode.Conflict);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage CompanyLogin([FromBody] UserLoginModel loginModel)
        {
            try
            {
                var company = _companyService.GetCompanyByNameOrEmail(loginModel.UserName);

                if (loginModel.Password == company.Password)
                {
                    CurrentUser.User = new CurrentUserViewModel
                    {
                        Name = company.Name,
                        IsClient = false,
                        UserId = company.CompanyId
                    };

                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage RegisterCompany([FromBody] Company company)
        {
            try
            {
                if (!_companyService.IsCompanyExist(company))
                {
                    _companyService.AddCompany(company);
                    return Request.CreateResponse(HttpStatusCode.Created);
                }

                return Request.CreateResponse(HttpStatusCode.Conflict);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetCurrentUser()
        {
            return Request.CreateResponse(HttpStatusCode.OK, CurrentUser.User);
        }

        [HttpPost]
        public HttpResponseMessage LogOff()
        {
            CurrentUser.User = null;
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}