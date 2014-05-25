using FluentNHibernate.Mapping;
using MobileBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Mappings
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Schema("dbo");
            Table("User");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.UserName).Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.RealName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.CreatedOn).Not.Nullable();

            References(x => x.Word).Column("WordId").Cascade.SaveUpdate();

            HasManyToMany(x => x.Tags)
                .Table("Crosswords_Tags")
                .ParentKeyColumn("CrosswordId")
                .ChildKeyColumn("TagId")
                .Cascade.SaveUpdate();
        }
    }
}
