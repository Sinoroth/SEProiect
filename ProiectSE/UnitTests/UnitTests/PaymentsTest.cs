using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace UnitTests
{
    [TestClass]
    class PaymentsTest
    {
        [TestMethod]
        public void TestMethodGetAll()
        {
            RestClient<Payment> rc = new RestClient<Payment>();
            rc.WebServiceUrl = "http://localhost:55428/api/payments/";
            var paymentList = rc.GetAsync();
            //-clear database
            //-call web api to add some test Payment info
            //-call web api to get info
            //-compare web api get result with added data
            List<Payment> testData = new List<Payment>();
            testData.Add(new Payments { ServicesToBePaid = "gas", AmountOfMoneyToBePaid = 4, Paid = "yes" });
            foreach (var p in testData)
                rc.PostAsync(p);

            var result = rc.GetAsync();
            Assert.AreEqual(testData.Count, result.Count);

        }
    }
}
