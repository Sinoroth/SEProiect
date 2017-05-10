using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //using (var db = new OwnersAssociationContext())
            //{
            //    db.Contracts.Add(new Contract { ContractId= 2, Supplier = "DIGI" , ContractPeriod = "10.03-10.06.2017", Cost = 45, ServicesFacilitiesOffered = "TV"});
            //    db.SaveChanges();

            //    //foreach (var contract in db.Contracts)
            //    //{
            //    //    Console.WriteLine(contract.Supplier);
            //    //}
            //}

            return View();
        }
    }
}
