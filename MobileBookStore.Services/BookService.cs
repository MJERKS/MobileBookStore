using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MobileBookStore.DataContracts;
using MobileBookStore.Model.Entities;
using MobileBookStore.ServiceContracts;

namespace MobileBookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository repository;

        public BookService(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return repository.AsQueryable<Book>().AsEnumerable();
        }

        public Book GetWhatEverBook()
        {
            return repository.FirstOrDefault<Book>(x => x.Id != 0);
        }
        public Book GetBookById(int id)
        {
            return repository.FirstOrDefault<Book>(x => x.Id == id);
        }

        public void DeleteBook(Book book)
        {
            repository.Delete(book);
            repository.Commit();
        }

        public Book CreateBook(Book book)
        {
            book.CreatedOn = DateTime.Now;
            repository.Save(book);
            repository.Commit();
            return book; //lol
        }
    }
}
