using System;
using FJB.Domain.Entities.Users;
using HttpClientExtenctions.Helpers;
using RJB.BLL.Models;

namespace HttpClientExtenctions.RequestHelpers
{
    public static class HttpUserService
    {
        public static CurrentUserViewModel ClientLogin(UserLoginModel loginModel)
        {
            var userViewModel = HttpClientHelper.PostDataAndGetResult<UserLoginModel, CurrentUserViewModel>(loginModel, string.Concat(Constants.UserUrl, "ClientLogin"));
            return userViewModel;
        }

        public static bool RegisterClient(Client client)
        {
            try
            {
                HttpClientHelper.PostData(client, string.Concat(Constants.UserUrl, "RegisterClient"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static CurrentUserViewModel CompanyLogin(UserLoginModel loginModel)
        {
            var userViewModel =
                HttpClientHelper.PostDataAndGetResult<UserLoginModel, CurrentUserViewModel>(loginModel, string.Concat(Constants.UserUrl, "CompanyLogin"));

            return userViewModel;
        }

        public static bool RegisterCompany(Company company)
        {
            try
            {
                HttpClientHelper.PostData(company, string.Concat(Constants.UserUrl, "RegisterCompany"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
