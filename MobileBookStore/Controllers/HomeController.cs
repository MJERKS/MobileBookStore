using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileBookStore.Data.DataContext;
using MobileBookStore.DataContracts;
using MobileBookStore.Data;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var bookRepo = new Repository();
            var book = bookRepo.FirstOrDefault<Book>(x => x.Id == 1);

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