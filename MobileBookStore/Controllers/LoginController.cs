using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MobileBookStore.Model.Entities;
using MobileBookStore.ServiceContracts;

namespace MobileBookStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var users = userService.GetAllUsers();
            return View(users);
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            var un = userService.GetUser(user.UserName);
            if (un == null)
            {
                User usr = userService.CreateUser(user.UserName, user.PasswordHash, user.RealName, user.Email);
                FormsAuthentication.SetAuthCookie(user.UserName, true);

                return RedirectToAction("Result", "Login");
            }
            else
            {
                ModelState.AddModelError("UserName", "Sorry, this username is already taken!");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = userService.GetUser(user.UserName, user.PasswordHash);
            if (usr != null)
            {
                //SUCCESS;
                //return RedirectToAction("Index", "Home");
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                return RedirectToAction("Result", "Login");
            }
            if (userService.GetUser(user.UserName) == null)
                ModelState.AddModelError("UserName", "username is incorrect.");
            else
                ModelState.AddModelError("PasswordHash", "password is incorrect");
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }
    }
}