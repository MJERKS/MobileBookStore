using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Entities
{
    class Book : PersistentEntityBase<Book>
    {
        public virtual int Id { get; set; }

        public virtual int PublisherId { get; set; }

        public virtual String Author { get; set; }

        public virtual String Title { get; set; }

        public virtual String FilePath { get; set; }

        public virtual int PageCount { get; set; }

        public virtual int Price { get; set; }
    }
}
