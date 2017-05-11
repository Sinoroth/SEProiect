using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using Plugin.RestClient;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public List<Employee> GetEmployees()
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employees/";
            var employeeList = rc.GetAsync();
            return employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employee/";
            var employee = rc.GetByIdAsync(id);
            return employee;
        }

        public bool PostEmployee(Employee e)
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employee/";
            bool response = rc.PostAsync(e);
            return response;
        }

        public bool PutEmployee(int id, Employee e)
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employee/";
            bool response = rc.PutAsync(id, e);
            return response;
        }

        public bool DeleteEmployee(int id, Employee e)
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employee/";
            bool response = rc.DeleteAsync(id, e);
            return response;
        }

        public ActionResult List()
        {
            //Employee employee = new Employee();
            //employee.EmployeeId = 1;
            //employee.EmployeeName = "Popescu Ana";
            //employee.Function = "janitor";
            //employee.Salary = 1000;
            //List<Employee> employeeList = new List<Employee>();
            //employeeList.Add(employee);
            List<Employee> employeeList = GetEmployees();

            return View(employeeList);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    } 
}