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
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (bookService == null)
            {
                ViewBag.Message = "repo is null";
                return View();
            }
            var book = bookService.GetWhatEverBook();

            if (book != null)
            {
                ViewBag.Message = book.ToString();
            }
            else
            {
                ViewBag.Message = "Stuff";
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}