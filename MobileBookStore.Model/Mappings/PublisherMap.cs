using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.Model.Mappings
{
    public class PublisherMap : PersistentEntityMapBase<Publisher>
    {
    
        public PublisherMap()
        {
            //Map(x => x.UserId);
            Map(x => x.CompanyName).Not.Nullable();

            References(x => x.User).Column("UserId");
            HasMany(x => x.PublishedBooks).KeyColumn("PublisherId").Cascade.DeleteOrphan();
        }
    }
}
