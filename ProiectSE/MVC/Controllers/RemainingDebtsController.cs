using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RemainingDebtsController : Controller
    {
        // GET: RemainingDebts
        public ActionResult List()
        {
            RemainingDebt rd = new RemainingDebt();
            rd.RemainingDebtId = 1;
            rd.ApartmentId = 1;
            rd.Month = "March";
            rd.DebtTo = "Electricity";
            rd.AmountOfMoneyOwed = 70;
            
            List<RemainingDebt> rdList = new List<RemainingDebt>();
            rdList.Add(rd);

            return View(rdList);
        }
    }
}