using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.ServiceContracts
{
    public interface IUserService
    {
        User GetUser(int userid);
        User GetUser(String username);
        User GetUser(String username, String password);
        User CreateUser(String username, String password, String realname, String email);
        IEnumerable<User> GetAllUsers();
        IEnumerable<Publisher> GetAllPublishers();
        void DeleteUser(User user);
        void PromoteToPublisher(User user);
    }
}
