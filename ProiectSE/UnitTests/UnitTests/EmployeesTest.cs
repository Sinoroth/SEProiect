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
    public class EmployeesTest
    {
        [TestMethod]
        public void TestMethodGetAllEmployees()
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employees/";
            var employeeList = rc.GetAsync();
            //-clear database
            //-call web api to add some test Employee info
            //-call web api to get info
            //-compare web api get result with added data
            List<Employee> testData = new List<Employee>();
            testData.Add(new Employee { EmployeeName="Popescu Ioana", Function="janitor", Salary=1000 });
            foreach (var e in testData)
                rc.PostAsync(e);

            var result = rc.GetAsync();
            Assert.AreEqual(testData.Count, result.Count);

        }
    }
}
