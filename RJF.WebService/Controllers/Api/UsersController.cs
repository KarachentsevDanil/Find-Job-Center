using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FJB.Domain.Entities.Users;
using Newtonsoft.Json;
using RJB.BLL.Users.Contracts;

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

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage ClientLogin([FromBody] Client client)
        {
            try
            {
                if (!_clientService.IsPasswordCorrect(client))
                {
                    var cookie = new HttpCookie("AuthorizationCookie", JsonConvert.SerializeObject(client));
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [System.Web.Mvc.HttpPost]
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

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage CompanyLogin([FromBody] Company company)
        {
            try
            {
                if (!_companyService.IsPasswordCorrect(company))
                {
                    var cookie = new HttpCookie("AuthorizationCookie", JsonConvert.SerializeObject(company));
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [System.Web.Mvc.HttpPost]
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
    }
}