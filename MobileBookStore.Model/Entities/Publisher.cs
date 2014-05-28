using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Entities
{
    public class Publisher : PersistentEntityBase<Publisher>
    {
        public virtual int UserId { get; set; }

        public virtual String CompanyName { get; set; }

        public virtual IList<Book> PublishedBooks { get; set; }

        public Publisher()
        {
            PublishedBooks = new List<Book>();
        }

        public virtual void AddPublishedBook(Book publishedBook) 
        {
            publishedBook.PublisherId = this.Id;
            PublishedBooks.Add(publishedBook);
        }
    }
}
