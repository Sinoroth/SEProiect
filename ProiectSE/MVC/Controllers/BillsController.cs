using MVC.Models;
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
        public ActionResult List()
        {
            Bill bill = new Bill();
            bill.BillId = 1;
            bill.BillType = "elecricity";
            bill.Month = "January";
            bill.ApartmentId = 1;
            bill.AmountOfMoneyOwed = 200;

            List<Bill> billList = new List<Bill>();

            billList.Add(bill);

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