using MobileBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Mappings
{
    public class TransactionMap : PersistentEntityMapBase<Transaction>
    {
        public TransactionMap()
        {
            Schema("dbo");
            Table("Transaction");

            Map(x => x.UserId).Not.Nullable();
            Map(x => x.BookId).Not.Nullable();
            Map(x => x.Amount).Not.Nullable();

            References(x => x.User);
            References(x => x.Book);

        }
    }
}
