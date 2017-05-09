using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}
        //public ActionResult MyProfile()
        //{
        //    return View();
        //}
        //public ActionResult Apartment()
        //{
        //    return View();
        //}
        //public ActionResult Bill()
        //{
        //    return View();
        //}
        //public ActionResult WaterConsumption()
        //{
        //    return View();
        //}
        //public ActionResult RemainingDebts()
        //{
        //    return View();
        //}
        //public ActionResult Payments()
        //{
        //    return View();
        //}
        //public ActionResult Contracts()
        //{
        //    return View();
        //}
        //public ActionResult Employees()
        //{
        //    return View();
        //}
    }
}