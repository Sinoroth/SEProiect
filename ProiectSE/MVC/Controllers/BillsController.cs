using MVC.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BillsController : Controller
    {
        // GET: Bills
        public List<Bill> GetBills()
        {
            RestClient<Bill> rc = new RestClient<Bill>();
            rc.WebServiceUrl = "http://localhost:55428/api/bills/";
            var billList = rc.GetAsync();
            return billList;
        }

        public Bill GetBillById(int id)
        {
            RestClient<Bill> rc = new RestClient<Bill>();
            rc.WebServiceUrl = "http://localhost:55428/api/bills/";
            var bill = rc.GetByIdAsync(id);
            return bill;
        }

        public bool PostBill(Bill b)
        {
            RestClient<Bill> rc = new RestClient<Bill>();
            rc.WebServiceUrl = "http://localhost:55428/api/bills/";
            bool response = rc.PostAsync(b);
            return response;
        }

        public bool PutBill(int id, Bill b)
        {
            RestClient<Bill> rc = new RestClient<Bill>();
            rc.WebServiceUrl = "http://localhost:55428/api/bills/";
            bool response = rc.PutAsync(id, b);
            return response;
        }

        public bool DeleteBill(int id)
        {
            RestClient<Bill> rc = new RestClient<Bill>();
            rc.WebServiceUrl = "http://localhost:55428/api/bills/";
            bool response = rc.DeleteAsync(id);
            return response;
        }

        public ActionResult List()
        {
            //Bill bill = new Bill();
            //bill.BillId = 1;
            //bill.BillType = "elecricity";
            //bill.Month = "January";
            //bill.ApartmentId = 1;
            //bill.AmountOfMoneyOwed = 200;

            //List<Bill> billList = new List<Bill>();

            //billList.Add(bill);
            UsersController uc = new UsersController();
            string email = Request.Cookies["UserCookie"].Value;
            List<User> user = new List<User>();
            user = uc.GetUserByEmail(email);
            if (user[0].Role == "user")
            {
                List<Bill> billList = new List<Bill>();
                foreach (var apartment in user[0].Apartments)
                {
                    foreach (var b in apartment.Bills)
                    {
                        billList.Add(b);
                    }
                }
                return View(billList);
            }
            else
            {
                List<Bill> billList = GetBills();
                return View(billList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Bill b)
        {

            PostBill(b);
            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {

            Bill b = GetBillById(id);

            return View(b);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Bill b)
        {

            PutBill(b.BillId, b);
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            Bill b = GetBillById(id);

            return View(b);
        }


        public ActionResult Delete(int id)
        {
            Bill b = GetBillById(id);
            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeleteBill(id);
            return RedirectToAction("List");

        }

    }
}