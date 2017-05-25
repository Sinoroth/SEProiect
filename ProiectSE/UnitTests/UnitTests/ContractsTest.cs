using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace UnitTests
{
    [TestClass]
    class ContractsTest
    {
        [TestMethod]
        public void TestMethodGetAll()
        {
            RestClient<Contract> rc = new RestClient<Contract>();
            rc.WebServiceUrl = "http://localhost:55428/api/contracts/";
            var contractList = rc.GetAsync();
            //-clear database
            //-call web api to add some test contract info
            //-call web api to get info
            //-compare web api get result with added data
            List<Contract> testData = new List<Contract>();
            testData.Add(new Contract { Supplier="Firma", ContractPeriod="10.05-20.05", ServicesFacilitiesOffered="reparatii", Cost=10 });
            foreach (var c in testData)
                rc.PostAsync(c);

            var result = rc.GetAsync();
            Assert.AreEqual(testData.Count, result.Count);

        }
    }
}
