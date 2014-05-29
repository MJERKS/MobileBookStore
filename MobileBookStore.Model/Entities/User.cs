using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBookStore.Model.Entities
{
    public class User : PersistentEntityBase<User>
    {
        [DisplayName("Username")]
        public virtual String UserName { get; set; }

        [DisplayName("Full name")]
        public virtual String RealName { get; set; }

        [DisplayName("Email")]
        public virtual String Email { get; set; }

        [DisplayName("Password")]
        public virtual String PasswordHash { get; set; }

        
    }
}
