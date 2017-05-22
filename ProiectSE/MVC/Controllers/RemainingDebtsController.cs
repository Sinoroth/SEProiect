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
        public List<RemainingDebt> GetRemainingDebts()
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            var rdList =  rc.GetAsync();
            return rdList;
        }

        public RemainingDebt GetRemainingDebtById(int id)
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            var rd = rc.GetByIdAsync(id);
            return rd;
        }

        public bool PostRemainingDebt(RemainingDebt rd)
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            bool response = rc.PostAsync(rd);
            return response;
        }

        public bool PutRemainingDebt(int id, RemainingDebt rd)
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            bool response = rc.PutAsync(id, rd);
            return response;
        }

        public bool DeleteRemainingDebt(int id)
        {
            RestClient<RemainingDebt> rc = new RestClient<RemainingDebt>();
            rc.WebServiceUrl = "http://localhost:55428/api/remainingdebts/";
            bool response = rc.DeleteAsync(id);
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
            UsersController uc = new UsersController();
            string email = Request.Cookies["UserCookie"].Value;
            List<User> user = new List<User>();
            user = uc.GetUserByEmail(email);
            if (user[0].Role == "user")
            {
                List<RemainingDebt> rdList = new List<RemainingDebt>();
                foreach (var apartment in user[0].Apartments)
                {
                    foreach (var rd in apartment.RemainingDebts)
                    {
                        rdList.Add(rd);
                    }
                }
                return View(rdList);
            }
            else
            {
                List<RemainingDebt> rdList = GetRemainingDebts();

                return View(rdList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.RemainingDebt rd)
        {

            PostRemainingDebt(rd);
            return RedirectToAction("List");
        }

        
        public ActionResult Edit(int id)
        {

            RemainingDebt rd = GetRemainingDebtById(id);
           
            return View(rd);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.RemainingDebt rd)
        {

            PutRemainingDebt(rd.RemainingDebtId, rd);
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            RemainingDebt rd = GetRemainingDebtById(id);

            return View(rd);
        }

        
        public ActionResult Delete(int id)
        {
            RemainingDebt rd = GetRemainingDebtById(id);
            //DeleteRemainingDebt(id);
            return View(rd);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeleteRemainingDebt(id);
            return RedirectToAction("List");

        }

        
    }
}