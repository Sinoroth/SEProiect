using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Model;
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
            rc.WebServiceUrl = "http://localhost:55428/api/employees/";
            var employee = rc.GetByIdAsync(id);
            return employee;
        }

        public bool PostEmployee(Employee e)
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employees/";
            bool response = rc.PostAsync(e);
            return response;
        }

        public bool PutEmployee(int id, Employee e)
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employees/";
            bool response = rc.PutAsync(id, e);
            return response;
        }

        public bool DeleteEmployee(int id)
        {
            RestClient<Employee> rc = new RestClient<Employee>();
            rc.WebServiceUrl = "http://localhost:55428/api/employees/";
            bool response = rc.DeleteAsync(id);
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

        [HttpPost]
        public ActionResult Create(Employee e)
        {

            PostEmployee(e);
            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {

            Employee e = GetEmployeeById(id);

            return View(e);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee e)
        {

            PutEmployee(e.EmployeeId, e);
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            Employee e = GetEmployeeById(id);

            return View(e);
        }


        public ActionResult Delete(int id)
        {
            Employee e = GetEmployeeById(id);
            return View(e);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeleteEmployee(id);
            return RedirectToAction("List");

        }

    }
}