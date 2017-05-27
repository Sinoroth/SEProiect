using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UsersTest
    {
        [TestMethod]
        public void TestMethodGetAllUsers()
        {
            RestClient<User> rc = new RestClient<User>();
            rc.WebServiceUrl = "http://localhost:55428/api/users/";
            var userList = rc.GetAsync();
            //-clear database
            //-call web api to add some test Payment info
            //-call web api to get info
            //-compare web api get result with added data
            List<User> testData = new List<User>();
            testData.Add(new User { UserId = 6, Name = "Ion Ion", PhoneNumber = "07827351", Email = "ion@email.com", Password = "123", Role = "user", Apartments = null });
            foreach (var p in testData)
                rc.PostAsync(p);

            var result = rc.GetAsync();
            Assert.AreEqual(testData.Count, result.Count);

        }
    }
}
