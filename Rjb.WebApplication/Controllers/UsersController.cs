using System.Web.Mvc;
using FJB.Domain.Entities.Users;
using HttpClientExtenctions.RequestHelpers;
using Rjb.WebApplication.Models;
using RJB.BLL.Models;

namespace Rjb.WebApplication.Controllers
{
    public class UsersController : Controller
    {

        public ActionResult Login()
        {
            UserClientService.LogOff();
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
            var isSuccess = UserClientService.ClientLogin(loginModel);

            if (!isSuccess || !ModelState.IsValid)
            {
                ModelState.AddModelError("Login", "Login failed.");
                return View("Login", loginModel);
            }

            CurrentUser.User = UserClientService.GetCurrentUser();

            return RedirectToAction("MyLeases", "Leases");
        }

        [HttpPost]
        public ActionResult RegisterClient(Client client)
        {
            var isSuccess = UserClientService.RegisterClient(client);

            if (!isSuccess)
            {
                ModelState.AddModelError("Registration", "Registration failed.");
                return View("RegisterClient", client);
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult LoginCompany(UserLoginModel loginModel)
        {
            var isSuccess = UserClientService.CompanyLogin(loginModel);

            if (!isSuccess)
            {
                ModelState.AddModelError("Login", "Login failed.");
                return View("Login", loginModel);
            }

            CurrentUser.User = UserClientService.GetCurrentUser();

            return RedirectToAction("AddRobot", "Robots");
        }

        [HttpPost]
        public ActionResult RegisterCompany(Company company)
        {
            var isSuccess = UserClientService.RegisterCompany(company);

            if (!isSuccess)
            {
                ModelState.AddModelError("Registration", "Registration failed.");
                return View("RegisterCompany", company);
            }

            return RedirectToAction("Login");
        }
    }
}