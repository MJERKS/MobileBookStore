using System.Collections;
using System.Collections.Generic;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.ServiceContracts
{
    public interface IBookService
    {
        Book GetWhatEverBook();
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();

        Book CreateBook(Book book);
        void DeleteBook(Book book);
    }
}
