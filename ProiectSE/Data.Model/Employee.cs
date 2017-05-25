using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Function { get; set; }
        public decimal Salary { get; set; }
    }
}