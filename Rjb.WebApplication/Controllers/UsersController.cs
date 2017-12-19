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
            var userViewModel = HttpUserService.ClientLogin(loginModel);

            if (userViewModel == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("Login", "User does not exists or password is incorrect.");
                return View("Login", loginModel);
            }

            CurrentUser.User = userViewModel;

            return RedirectToAction("MyLeases", "Leases");
        }

        [HttpPost]
        public ActionResult RegisterClient(Client client)
        {
            var isSuccess = HttpUserService.RegisterClient(client);

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
            var userViewModel = HttpUserService.CompanyLogin(loginModel);

            if (userViewModel == null)
            {
                ModelState.AddModelError("Login", "Company does not exists or password is incorrect.");
                return View("Login", loginModel);
            }

            CurrentUser.User = userViewModel;

            return RedirectToAction("CompanyRobots", "Robots");
        }

        [HttpPost]
        public ActionResult RegisterCompany(Company company)
        {
            var isSuccess = HttpUserService.RegisterCompany(company);

            if (!isSuccess)
            {
                ModelState.AddModelError("Registration", "Registration failed.");
                return View("RegisterCompany", company);
            }

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            CurrentUser.User = null;
            return RedirectToAction("Login");
        }
    }
}