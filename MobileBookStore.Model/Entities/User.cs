using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Entities
{
    public class User : PersistentEntityBase<User>
    {
        public virtual String UserName { get; set; }

        public virtual String PasswordHash { get; set; }

        public virtual String RealName { get; set; }

        public virtual String Email { get; set; }

        public virtual IList<Book> BoughtBooks { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }

        public virtual Publisher Publisher { get; set; }

        public User()
        {
            BoughtBooks = new List<Book>();
            Transactions = new List<Transaction>();
        }

        public virtual void AddBoughtBook(Book book)
        {
            BoughtBooks.Add(book);
        }

        public virtual void AddTransaction(Transaction transaction)
        {
            transaction.UserId = this.Id;
            Transactions.Add(transaction);
        }

        public virtual void BecomePublisher(Publisher publisher)
        {
            publisher.UserId = this.Id;
            this.Publisher = publisher;
        }
    }
}
