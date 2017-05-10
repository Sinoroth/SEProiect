using MVC.Models;
using Newtonsoft.Json;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RemainingDebtsController : Controller
    {
        // GET: RemainingDebts
        public async Task<List<RemainingDebt>> GetRemainingDebts()
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            var rdList = await rc.GetAsync();
            return rdList;
        }

        public async Task<RemainingDebt> GetRemainingDebtById(int id)
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            var rd = await rc.GetByIdAsync(id);
            return rd;
        }

        public async Task<bool> PostRemainingDebt(RemainingDebt rd)
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            bool response = await rc.PostAsync(rd);
            return response;
        }

        public async Task<bool> PutRemainingDebt(int id, RemainingDebt rd)
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            bool response = await rc.PutAsync(id, rd);
            return response;
        }

        public async Task<bool> DeleteRemainingDebt(int id, RemainingDebt rd)
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            bool response = await rc.DeleteAsync(id, rd);
            return response;
        }


        public ActionResult List()
        {
            //RemainingDebt rd = new RemainingDebt();
            //rd.RemainingDebtId = 1;
            //rd.ApartmentId = 1;
            //rd.Month = "March";
            //rd.DebtTo = "Electricity";
            //rd.AmountOfMoneyOwed = 70;

            //Apartment apartment = new Apartment();
            //apartment.ApartmentId = 1;
            //apartment.ApartmentNumber = "ap.5(bl.E70)";
            //apartment.UserId = 1;
            //apartment.AmountOfMoneyOwed = 59;
            //apartment.NumberOfOccupants = 3;

            //rd.Apartment = apartment;

            //List<RemainingDebt> rdList = new List<RemainingDebt>();
            //rdList.Add(rd);
            //List<RemainingDebt> rdList = GetAsync();

            return View();
        }

        public ActionResult Create()
        {

            //PostAsync();
            return View();
        }

        public ActionResult Edit()
        {
            //PutAsync();
            return View();
        }

        public ActionResult Details()
        {
            //GetByIdAsync();
            return View();
        }

        public ActionResult Delete()
        {
            //DeleteAsync();
            return View();
        }
    }
}