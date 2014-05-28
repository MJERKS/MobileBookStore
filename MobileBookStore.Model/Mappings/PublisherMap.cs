﻿using System;
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
            Schema("dbo");
            Table("Publisher");

            Map(x => x.UserId);
            Map(x => x.CompanyName).Not.Nullable();

            References(x => x.User);
            HasMany(x => x.PublishedBooks)
                .Cascade.All();
        }
    }
}
