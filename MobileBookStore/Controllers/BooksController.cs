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
    public class BooksController : Controller
    {
        // GET: Books
        private readonly IBookService bookService;
        private readonly IUserService userService;

        public BooksController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var books = bookService.GetAllBooks();
            //var books = new List<Book>() {bookService.GetWhatEverBook()};
            return View(books);
        }


        [Authorize]
        public ActionResult Create()
        {
            var them = userService.GetAllPublishers().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var bk = bookService.CreateBook(book);
            }

            return RedirectToAction("Index", "Books");
            
            /*else
            {
                ModelState.AddModelError("UserName", "Sorry, this username is already taken!");
                return View();
            }*/
        }

        public ActionResult Read(Book book)
        {
            //http://classes.soe.ucsc.edu/cmps112/Spring03/languages/prolog/PrologIntro.pdf
            return View(book);
        }
    }
}