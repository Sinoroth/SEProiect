using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace UnitTests
{
    [TestClass]
    class BillsTest
    {
        [TestMethod]
        public void TestMethodGetAll()
        {
            RestClient<Bill> rc = new RestClient<Bill>();
            rc.WebServiceUrl = "http://localhost:55428/api/bills/";
            var billList = rc.GetAsync();
            //-clear database
            //-call web api to add some test bill info
            //-call web api to get info
            //-compare web api get result with added data
            List<Bill> testData = new List<Bill>();
            testData.Add( new Bill { BillType = "gas", Month = "may", AmountOfMoneyOwed = 4});
            foreach (var b in testData)
                rc.PostAsync(b);

            var result = rc.GetAsync();
            Assert.AreEqual(testData.Count, result.Count);

        }
    }
}
