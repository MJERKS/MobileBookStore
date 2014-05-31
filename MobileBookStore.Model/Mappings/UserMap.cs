using FluentNHibernate.Mapping;
using MobileBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;

namespace MobileBookStore.Model.Mappings
{
    public class UserMap : PersistentEntityMapBase<User>
    {
        public UserMap()
        {
            Map(x => x.UserName).Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.RealName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();

            HasManyToMany(x => x.BoughtBooks)
                .Cascade.All()
                .Table("User_BoughtBooks");

            HasOne(x => x.Administrator).PropertyRef(x => x.User).Cascade.Delete();
            HasOne(x => x.Publisher).PropertyRef(x => x.User).Cascade.Delete();
        }
    }
}
