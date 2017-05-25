using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plugin.RestClient;
using Data.Model;
using System.Collections.Generic;

namespace UnitTests
{

    [TestClass]
    public class ApartmentsTest
    {
        [TestMethod]
        public void TestMethodGetAll()
        {
            RestClient<Apartment> rc = new RestClient<Apartment>();
            rc.WebServiceUrl = "http://localhost:55428/api/apartments/";
            var apartmentList = rc.GetAsync();
            //-clear database
            //-call web api to add some test apartment info
            //-call web api to get info
            //-compare web api get result with added data
            List<Apartment> testData = new List<Apartment>();
            testData.Add(new Apartment { ApartmentNumber = "12", NumberOfOccupants = 2, AmountOfMoneyOwed = 4, new Bill { BillType = "gas", Month = "may", AmountOfMoneyOwed=4 },new Payments { ServicesToBePaid="gas", AmountOfMoneyToBePaid=4, Paid="yes" },new RemainingDebts { DebtTo="electricity", Month="may", AmountOfMoneyOwed=4 }, new WaterConsumption { PricePerUnit=2, Consumption=10, AmountOfMoneyOwed=20 } });
            foreach (var ap in testData)
                rc.PostAsync(ap);

            var result = rc.GetAsync();
            Assert.AreEqual(testData.Count, result.Count);

        }
    }
}
