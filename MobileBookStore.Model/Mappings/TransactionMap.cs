using FluentNHibernate.Mapping;
using MobileBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Mappings
{
    class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Schema("dbo");
            Table("Transaction");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.UserId).Not.Nullable();
            Map(x => x.BookId).Not.Nullable();
            Map(x => x.Amount).Not.Nullable();
            Map(x => x.CreatedOn).Not.Nullable();
        }
    }
}
