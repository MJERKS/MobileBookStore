using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileBookStore.Model.Entities;
using MobileBookStore.ServiceContracts;

namespace MobileBookStore.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Index()
        {
            var books = bookService.GetAllBooks();
            //var books = new List<Book>() {bookService.GetWhatEverBook()};
            return View(books);
        }
    }
}