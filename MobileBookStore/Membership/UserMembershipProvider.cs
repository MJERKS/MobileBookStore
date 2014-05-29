using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using MobileBookStore.Model.Entities;
using MobileBookStore.ServiceContracts;

namespace MobileBookStore.Membership
{
    public abstract class UserMembershipProvider : System.Web.Security.MembershipProvider
    {
        protected IUserService userService;

        protected UserMembershipProvider(IUserService userService)
        {
            this.userService = userService;
        }

        public override bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            var hasher = SHA256.Create();
            var passwordHash = Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(password)));
            User user = userService.GetUser(username);
            if (user == null) return false;

            return user.PasswordHash == passwordHash;
        }
    }
}