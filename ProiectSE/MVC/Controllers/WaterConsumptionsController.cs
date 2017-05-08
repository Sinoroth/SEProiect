using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class WaterConsumptionsController : Controller
    {
        // GET: WaterConsumptions
        public ActionResult List()
        {
            WaterConsumption wCons = new WaterConsumption();
            wCons.WaterConsumptionId = 1;
            wCons.ApartmentId = 1;
            wCons.PricePerUnit = 20;
            wCons.Consumption = 10;
            wCons.AmountOfMoneyOwed = 200;
            List<WaterConsumption> wConsList = new List<WaterConsumption>();
            wConsList.Add(wCons);

            return View(wConsList);
        }
    }
}