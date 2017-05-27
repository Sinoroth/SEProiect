using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Plugin.RestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class WaterConsumptionsTest
    {
        [TestMethod]
        public void TestMethodGetAllWaterConsumptions()
        {
            RestClient<WaterConsumption> rc = new RestClient<WaterConsumption>();
            rc.WebServiceUrl = "http://localhost:55428/api/waterconsumptions/";
            var waterConsumptionList = rc.GetAsync();
            //-clear database
            //-call web api to add some test waterConsumption info
            //-call web api to get info
            //-compare web api get result with added data
            List<WaterConsumption> testData = new List<WaterConsumption>();
            testData.Add(new WaterConsumption {ApartmentId = 12, PricePerUnit = 2, Consumption = 10, AmountOfMoneyOwed = 20 });
            foreach (var wc in testData)
                rc.PostAsync(wc);

            var result = rc.GetAsync();
            Assert.AreEqual(testData.Count, result.Count);

        }
    }
}
