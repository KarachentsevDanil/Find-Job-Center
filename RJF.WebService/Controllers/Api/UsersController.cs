using System;
using System.Web.Http;
using FJB.Domain.Entities.Users;
using RJB.BLL.Models;
using RJB.BLL.Users;
using RJB.BLL.Users.Contracts;

namespace RJF.WebService.Controllers.Api
{
    public class UsersController : ApiController
    {
        private readonly IClientService _clientService;
        private readonly ICompanyService _companyService;

        public UsersController()
        {
            _clientService = new ClientService();
            _companyService = new CompanyService();
        }

        [HttpPost]
        public CurrentUserViewModel ClientLogin([FromBody] UserLoginModel loginModel)
        {
            var client = _clientService.GetClientByUsername(loginModel.UserName);

            if (client != null && loginModel.Password == client.Password)
            {
                var user = new CurrentUserViewModel
                {
                    Name = client.Username,
                    IsClient = true,
                    Role = client.Role,
                    UserId = client.ClientId,
                    Password = client.Password
                };

                return user;
            }

            throw new Exception("User does not exists or password is incorrect.");
        }

        [HttpPost]
        public void RegisterClient([FromBody] Client client)
        {
            if (!_clientService.IsClientExist(client))
            {
                _clientService.AddClient(client);
                return;
            }

            throw new Exception("User already exists.");
        }

        [HttpPost]
        public CurrentUserViewModel CompanyLogin([FromBody] UserLoginModel loginModel)
        {
            var company = _companyService.GetCompanyByNameOrEmail(loginModel.UserName);

            if (company != null && loginModel.Password == company.Password)
            {
                var user = new CurrentUserViewModel
                {
                    Name = company.Email,
                    IsClient = false,
                    UserId = company.CompanyId,
                    Password = company.Password
                };

                return user;
            }

            throw new Exception("Company does not exists or password is incorrect.");
        }

        [HttpPost]
        public void RegisterCompany([FromBody] Company company)
        {
            if (!_companyService.IsCompanyExist(company))
            {
                _companyService.AddCompany(company);
                return;
            }

            throw new Exception("Company already exists.");
        }
    }
}