using FluentNHibernate.Mapping;
using MobileBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Mappings
{
    public class UserMap : PersistentEntityMapBase<User>
    {
        public UserMap()
        {
            Schema("dbo");
            Table("User");

            Map(x => x.UserName).Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.RealName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();

            HasManyToMany(x => x.BoughtBooks)
                .Cascade.All()
                .Table("User_BoughtBooks");

            HasMany(x => x.Transactions)
                .Cascade.All();

            //References(x => x.Publisher)
            //    .Cascade.All();
        }
    }
}
