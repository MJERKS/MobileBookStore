using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileBookStore.DataContracts;
using MobileBookStore.ServiceContracts;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Books");

            return View();
        }
    }
}