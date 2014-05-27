using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Entities
{
    public class User : PersistentEntityBase<User>
    {
        public virtual int Id { get; set; }

        public virtual String UserName { get; set; }

        public virtual String PasswordHash { get; set; }

        public virtual String RealName { get; set; }

        public virtual String Email { get; set; }
    }
}
