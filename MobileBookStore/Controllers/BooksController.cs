using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MobileBookStore.Helpers;
using MobileBookStore.Model.Entities;
using MobileBookStore.ServiceContracts;
using MobileBookStore.ViewModels;

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
        }

        public ActionResult Read(Book book)
        {
            var rBook = bookService.GetBookById(book.Id);
            return View(rBook);
        }

        public ActionResult Preview(Book book)
        {
            var appPath = Request.PhysicalApplicationPath;
            var rBook = bookService.GetBookById(book.Id);
            var list = FileManager.GeneratePreviewImages(rBook, appPath);
            return View(new PreviewViewModel(rBook, list, FileManager.ImageFolder));
        }

        public ActionResult Delete(Book book)
        {
            bookService.DeleteBook(book);
            return RedirectToAction("Index", "Books");
        }
    }
}