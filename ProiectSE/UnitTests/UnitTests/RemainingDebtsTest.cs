using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace UnitTests
{
    [TestClass]
    class RemainingDebtsTest
    {
        [TestMethod]
        public void TestMethodGetAll()
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            var rdList = rc.GetAsync();
            //-clear database
            //-call web api to add some test RemainingDebt info
            //-call web api to get info
            //-compare web api get result with added data
            List<RemainingDebt> testData = new List<RemainingDebt>();
            testData.Add(new RemainingDebts { DebtTo = "electricity", Month = "may", AmountOfMoneyOwed = 4  });
            foreach (var rd in testData)
                rc.PostAsync(rd);

            var result = rc.GetAsync();
            Assert.AreEqual(testData.Count, result.Count);

        }
    }
}
