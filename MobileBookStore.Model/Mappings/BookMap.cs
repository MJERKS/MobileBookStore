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
    class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Schema("dbo");
            Table("Book");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.PublisherId).Not.Nullable();
            Map(x => x.Author).Not.Nullable();
            Map(x => x.Title).Not.Nullable();
            Map(x => x.FilePath).Not.Nullable();
            Map(x => x.PageCount).Not.Nullable();
            Map(x => x.Price).Not.Nullable();
            Map(x => x.CreatedOn).Not.Nullable();
        }
    }
}
