using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.Model.Mappings
{
    public class AdministratorMap : PersistentEntityMapBase<Administrator>
    {
        public AdministratorMap()
        {
            References(x => x.User).Column("UserId");
        }
    }
}
