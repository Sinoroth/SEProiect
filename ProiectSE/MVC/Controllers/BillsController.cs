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

        //public bool DeleteBill(int id, Bill b)
        //{
        //    RestClient<Bill> rc = new RestClient<Bill>();
        //    rc.WebServiceUrl = "http://localhost:55428/api/bills/";
        //    bool response = rc.DeleteAsync(id, b);
        //    return response;
        //}

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
            List<Bill> billList = GetBills();
            return View(billList);
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