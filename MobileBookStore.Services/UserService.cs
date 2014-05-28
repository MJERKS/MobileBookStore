using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MobileBookStore.DataContracts;
using MobileBookStore.Model.Entities;
using MobileBookStore.ServiceContracts;

namespace MobileBookStore.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public User GetUser(String username)
        {
            return repository.FirstOrDefault<User>(x => x.UserName == username);
        }

        public User GetUser(String username, String password)
        {
            var hasher = SHA256.Create();
            var passwordHash = Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return repository.FirstOrDefault<User>(x => x.UserName == username && x.PasswordHash == passwordHash);
        }

        public User CreateUser(String username, String password, String realname)
        {
            var hasher = SHA256.Create();
            var passwordHash = Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(password)));

            var user = new User()
            {
                Email = username,
                UserName = username,
                RealName = realname,
                PasswordHash = passwordHash
            };

            repository.Save(user);

            return user;
        }
    }
}
