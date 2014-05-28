using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileBookStore.DataContracts;
using MobileBookStore.Data;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (repository == null)
            {
                ViewBag.Message = "repo is null";
                return View();
            }
            var book = repository.FirstOrDefault<Book>(x => x.Id == 2);

            ViewBag.Message = book.ToString();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}