using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using MobileBookStore.Model.Entities;
using MobileBookStore.Models;
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

        public ActionResult LoginHeader()
        {
            var model = new LoginHeaderViewModel();
            var usr = userService.GetUser(System.Web.HttpContext.Current.User.Identity.GetUserName());
            if (usr != null)
            {
                if (usr.Administrator != null)
                    model.isAdmin = true;
            }

            return PartialView(model);
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
                FormsAuthentication.SetAuthCookie(usr.UserName, true);

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

        [Authorize]
        public ActionResult List()
        {
            var usr = userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if (usr.Administrator == null)
                return RedirectToAction("Index", "Books");

            var users = userService.GetAllUsers();
            return View(users);
        }

        [Authorize]
        public ActionResult Promote(int id)
        {
            var usr = userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if (usr.Administrator == null)
                return RedirectToAction("Index", "Books");

            var user = userService.GetUser(id);
            userService.PromoteToPublisher(user);

            return RedirectToAction("List");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var usr = userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if (usr.Administrator == null)
                return RedirectToAction("Index", "Books");

            var user = userService.GetUser(id);
            userService.DeleteUser(user);

            return RedirectToAction("List");
        }

        public ActionResult Result()
        {
            return View();
        }
    }
}