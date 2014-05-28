using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Entities
{
    public class Transaction : PersistentEntityBase<Transaction>
    {
        public virtual int UserId { get; set; }

        public virtual int BookId { get; set; }

        public virtual Decimal Amount { get; set; }

        public virtual User User { get; set; }

        public virtual Book Book { get; set; } 
    }
}
