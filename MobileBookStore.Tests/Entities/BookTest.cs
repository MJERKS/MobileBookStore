using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileBookStore.App_Start;
using MobileBookStore.Data;
using MobileBookStore.DataContracts;
using MobileBookStore.Model.Entities;
using Ninject;

namespace MobileBookStore.Tests.Entities
{
    [TestClass]
    public class BookTest
    {
        private IRepository repository;

        [TestInitialize]
        public void MyTestInitialize()
        {
            var kernel = NinjectWebCommon.CreatePublicKernel();
            repository = kernel.Get<Repository>();
        }

        [TestMethod]
        public void TestMapping()
        {
            var user = new User()
            {
                Email = "test@email.com",
                UserName = "test@email.com",
                PasswordHash = "Something",
                RealName = "TestName",
                CreatedOn = new DateTime(2010,1,1)
            };
            repository.Save(user);

            var publisher = new Publisher()
            {
                CompanyName = "",
                UserId = user.Id,
                CreatedOn = new DateTime(2010, 1, 1)
            };
            repository.Save(publisher);

            var book = new Book()
            {
                PublisherId = publisher.Id,
                Author = "test-title",
                FilePath = "file-path",
                PageCount = 12,
                Price = 10,
                Title = "test",
                CreatedOn = new DateTime(2010, 1, 1),
            };
            repository.Save(book);

            var retrievedUser = repository.FirstOrDefault<User>(x => x.Email == "test@email.com");

            Assert.AreEqual(retrievedUser.RealName, user.RealName);

            repository.Delete(user);
            repository.Delete(book);
        }
    }
}
