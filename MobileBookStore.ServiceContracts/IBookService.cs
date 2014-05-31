using System.Collections;
using System.Collections.Generic;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.ServiceContracts
{
    public interface IBookService
    {
        Book GetWhatEverBook();
        IEnumerable<Book> GetAllBooks();

        Book CreateBook(Book book);
    }
}
