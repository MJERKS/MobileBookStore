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

        public IEnumerable<User> GetAllUsers()
        {
            return repository.AsQueryable<User>().AsEnumerable();
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

        public User CreateUser(String username, String password, String realname, String email)
        {
            var rand = new Random();
            var hasher = SHA256.Create();
            var passwordHash = Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(password)));

            var user = new User()
            {
                Email = email,
                UserName = username,
                RealName = realname,
                PasswordHash = passwordHash,
                CreatedOn = DateTime.Now, // be šito irgi (turi but date between 1753m. ir 9999m.)
                //Id = rand.Next(0, 2147483647), //be šito sako kad err mappinime, wtf, should be fixed somehow...
            };

            repository.Save(user);

            return user;
        }
    }
}
