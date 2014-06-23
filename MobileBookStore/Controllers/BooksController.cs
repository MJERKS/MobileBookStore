using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using MobileBookStore.Helpers;
using MobileBookStore.Model.Entities;
using MobileBookStore.ServiceContracts;
using MobileBookStore.ViewModels;
using MobileBookStore.Models;

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
            var model = new BookListModel { bookList = books, isAdmin = false };

            var usr = userService.GetUser(System.Web.HttpContext.Current.User.Identity.GetUserName());
            if (usr != null)
            {
                if (usr.Administrator != null)
                    model.isAdmin = true;
                if (usr.Publisher != null)
                    model.publisher = usr.Publisher;
            }

            return View(model);
        }


        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Book book)
        {
            var usr = userService.GetUser(System.Web.HttpContext.Current.User.Identity.GetUserName());
            if (usr != null)
            {
                if (usr.Administrator != null || usr.Publisher != null)
                {
                    if (usr.Publisher != null)
                    {
                        book.Publisher = usr.Publisher;
                        book.PublisherId = usr.Publisher.Id;
                    }
                    bookService.CreateBook(book);
                }
            }

            return RedirectToAction("Index", "Books");
        }

        [Authorize]
        public ActionResult Read(int bookId)
        {
            var rBook = bookService.GetBookById(bookId);
            return View(rBook);
        }

        [Authorize]
        public ActionResult Preview(int bookId)
        {
            var appPath = Request.PhysicalApplicationPath;
            var rBook = bookService.GetBookById(bookId);
            var list = FileManager.GeneratePreviewImages(rBook, appPath);
            return View(new PreviewViewModel(rBook, list, FileManager.ImageFolder));
        }

        [Authorize]
        public ActionResult Delete(int bookId)
        {
            var usr = userService.GetUser(System.Web.HttpContext.Current.User.Identity.GetUserName());
            if (usr != null)
            {
                var rBook = bookService.GetBookById(bookId);
                if (usr.Administrator != null || (usr.Publisher != null && rBook.Publisher == usr.Publisher))
                {
                    bookService.DeleteBook(rBook);
                }
            }
            return RedirectToAction("Index", "Books");
        }

        [Authorize]
        public ActionResult Buy(int bookId)
        {
            return View();
        }
    }
}