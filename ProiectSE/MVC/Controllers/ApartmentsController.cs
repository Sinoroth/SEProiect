using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ApartmentsController : Controller
    {
        // GET: Apartments
        public ActionResult List()
        {
            Apartment apartment = new Apartment();
            apartment.ApartmentId = 1;
            apartment.ApartmentNumber = "ap.5(bl.E70)";
            apartment.UserId = 1;
            apartment.AmountOfMoneyOwed = 59;
            apartment.NumberOfOccupants = 3;

            List<Apartment> apartmentList = new List<Apartment>();

            return View(apartmentList);
        }
    }
}