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
using Publisher = MobileBookStore.Model.Entities.Publisher;

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

        public IEnumerable<Model.Entities.Publisher> GetAllPublishers()
        {
            return repository.AsQueryable<Model.Entities.Publisher>().AsEnumerable();
        }

        public User GetUser(int userid)
        {
            return repository.FirstOrDefault<User>(x => x.Id == userid);
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
                CreatedOn = DateTime.Now
            };

            repository.Save(user);

            return user;
        }

        public void DeleteUser(User user)
        {
            repository.Delete(user);
            repository.Commit();
        }

        public void PromoteToPublisher(User user)
        {
            var publisher = new Publisher()
            {
                User = user,
                UserId = user.Id,
                CreatedOn = DateTime.Now,
                CompanyName = "A new company name"
            };

            repository.Save(publisher);
            repository.Commit();
        }
    }
}
