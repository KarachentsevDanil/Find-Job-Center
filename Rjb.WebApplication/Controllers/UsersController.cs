using System.Web.Mvc;
using FJB.Domain.Entities.Users;
using HttpClientExtenctions.RequestHelpers;
using Rjb.WebApplication.Models;
using RJB.BLL.Models;

namespace Rjb.WebApplication.Controllers
{

    [AllowAnonymous]
    public class UsersController : Controller
    {

        public ActionResult Login()
        {
            UsersRequestHelper.LogOff();
            CurrentUser.User = null;
            return View();
        }

        public ActionResult RegisterClient()
        {
            return View();
        }

        public ActionResult RegisterCompany()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginClient(UserLoginModel loginModel)
        {
            var isSuccess = UsersRequestHelper.ClientLogin(loginModel);

            if (!isSuccess || !ModelState.IsValid)
            {
                ModelState.AddModelError("Login", "Login failed.");
                return RedirectToAction("Login", ModelState);
            }

            CurrentUser.User = UsersRequestHelper.GetCurrentUser();

            return RedirectToAction("MyLeases", "Leases");
        }

        [HttpPost]
        public ActionResult RegisterClient(Client client)
        {
            var isSuccess = UsersRequestHelper.RegisterClient(client);

            if (!isSuccess)
            {
                ModelState.AddModelError("Registration", "Registration failed.");
                return RedirectToAction("RegisterClient", ModelState);
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult LoginCompany(UserLoginModel loginModel)
        {
            var isSuccess = UsersRequestHelper.CompanyLogin(loginModel);

            if (!isSuccess)
            {
                ModelState.AddModelError("Login", "Login failed.");
                return RedirectToAction("Login", ModelState);
            }

            CurrentUser.User = UsersRequestHelper.GetCurrentUser();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult RegisterCompany(Company company)
        {
            var isSuccess = UsersRequestHelper.RegisterCompany(company);

            if (!isSuccess)
            {
                ModelState.AddModelError("Registration", "Registration failed.");
                return RedirectToAction("RegisterCompany", ModelState);
            }

            return RedirectToAction("Login");
        }
    }
}