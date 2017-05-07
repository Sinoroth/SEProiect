using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ContractsController : Controller
    {
        // GET: Contracts
        public ActionResult List()
        {
            Contract contract = new Contract();
            contract.ContractId = 1;
            contract.ContractPeriod = "10.05.2016 - 10.05.2017";
            contract.Cost = 2000;
            contract.Supplier = "Digi";
            contract.ServicesFacilitiesOffered = "TV";
            List<Contract> contractList = new List<Contract>();
            contractList.Add(contract);

            return View(contractList);
        }
    }
}