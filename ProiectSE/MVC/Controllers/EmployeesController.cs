using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult List()
        {
            Employee employee = new Employee();
            employee.EmployeeId = 1;
            employee.EmployeeName = "Popescu Ana";
            employee.Function = "janitor";
            employee.Salary = 1000;
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(employee);
            return View(employeeList);
        }
    } 
}