using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Entities
{
    public class Book : PersistentEntityBase<Book>
    {
        [DisplayName("Publisher Id")]
        public virtual int PublisherId { get; set; }

        [DisplayName("Author")]
        public virtual String Author { get; set; }

        [DisplayName("Book title")]
        public virtual String Title { get; set; }

        [DisplayName("Path to the book")]
        public virtual String FilePath { get; set; }

        [DisplayName("No. of pages")]
        public virtual int PageCount { get; set; }

        [DisplayName("Price")]
        public virtual int Price { get; set; }

        //public virtual Publisher Publisher { get; set; } 
    }
}
