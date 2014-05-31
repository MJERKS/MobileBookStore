using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Entities
{
    public class Administrator : PersistentEntityBase<Administrator>
    {
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
