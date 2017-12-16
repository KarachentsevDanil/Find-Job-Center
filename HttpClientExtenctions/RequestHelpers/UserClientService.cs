using System;
using FJB.Domain.Entities.Users;
using HttpClientExtenctions.Helpers;
using RJB.BLL.Models;

namespace HttpClientExtenctions.RequestHelpers
{
    public static class UserClientService
    {
        private static string UserUrl = "/api/users/";

        public static CurrentUserViewModel ClientLogin(UserLoginModel loginModel)
        {
            try
            {
                var userViewModel = HttpClientHelper.PostDataAndGetResult<UserLoginModel, CurrentUserViewModel>(loginModel, string.Concat(UserUrl, "ClientLogin"));
                return userViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool RegisterClient(Client client)
        {
            try
            {
                HttpClientHelper.PostData(client, string.Concat(UserUrl, "RegisterClient"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static CurrentUserViewModel CompanyLogin(UserLoginModel loginModel)
        {
            try
            {
                var userViewModel = 
                    HttpClientHelper.PostDataAndGetResult<UserLoginModel, CurrentUserViewModel>(loginModel, string.Concat(UserUrl, "CompanyLogin"));

                return userViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool RegisterCompany(Company company)
        {
            try
            {
                HttpClientHelper.PostData(company, string.Concat(UserUrl, "RegisterCompany"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
