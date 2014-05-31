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
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
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
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Books");

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Books");

            var un = userService.GetUser(user.UserName);
            if (un == null)
            {
                User usr = userService.CreateUser(user.UserName, user.PasswordHash, user.RealName, user.Email);
                FormsAuthentication.SetAuthCookie(user.UserName, true);

                return RedirectToAction("Index", "Books");
            }
            else
            {
                ModelState.AddModelError("UserName", "Sorry, this username is already taken!");
                return View();
            }
        }

        public ActionResult Login()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Books");

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Books");

            var usr = userService.GetUser(user.UserName, user.PasswordHash);
            if (usr != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                return RedirectToAction("Index", "Books");
            }
            if (userService.GetUser(user.UserName) == null)
                ModelState.AddModelError("UserName", "username is incorrect.");
            else
                ModelState.AddModelError("PasswordHash", "password is incorrect");
            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Result()
        {
            return View();
        }
    }
}