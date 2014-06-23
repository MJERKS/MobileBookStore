using MobileBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileBookStore.Models
{
    public class BookListModel
    {
        public bool isAdmin { get; set; }
        public Publisher publisher { get; set; }
        public IEnumerable<MobileBookStore.Model.Entities.Book> bookList { get; set; }
    }
}