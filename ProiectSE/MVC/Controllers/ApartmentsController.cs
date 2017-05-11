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
    public class ApartmentsController : Controller
    {
        // GET: Apartments
        public List<Apartment> GetApartments()
        {
            RestClient<Apartment> rc = new RestClient<Apartment>();
            rc.WebServiceUrl = "http://localhost:55428/api/apartments/";
            var apartmentList = rc.GetAsync();
            return apartmentList;
        }

        public async Task<Apartment> GetApartmentById(int id)
        {
            RestClient<Apartment> rc = new RestClient<Apartment>();
            rc.WebServiceUrl = "http://localhost:55428/api/apartments/";
            var apartment = await rc.GetByIdAsync(id);
            return apartment;
        }

        public async Task<bool> PostApartment(Apartment a)
        {
            RestClient<Apartment> rc = new RestClient<Apartment>();
            rc.WebServiceUrl = "http://localhost:55428/api/apartments/";
            bool response = await rc.PostAsync(a);
            return response;
        }

        public async Task<bool> PutApartment(int id, Apartment a)
        {
            RestClient<Apartment> rc = new RestClient<Apartment>();
            rc.WebServiceUrl = "http://localhost:55428/api/apartments/";
            bool response = await rc.PutAsync(id, a);
            return response;
        }

        public async Task<bool> DeleteApartment(int id, Apartment a)
        {
            RestClient<Apartment> rc = new RestClient<Apartment>();
            rc.WebServiceUrl = "http://localhost:55428/api/apartments/";
            bool response = await rc.DeleteAsync(id, a);
            return response;
        }

        public ActionResult List()
        {

            //Apartment apartment = new Apartment();
            //apartment.ApartmentId = 1;
            //apartment.ApartmentNumber = "ap.5(bl.E70)";
            //apartment.UserId = 1;
            //apartment.AmountOfMoneyOwed = 59;
            //apartment.NumberOfOccupants = 3;
            #region
            ////Bill bill = new Bill();
            ////bill.BillId = 1;
            ////bill.BillType = "elecricity";
            ////bill.Month = "January";
            ////bill.ApartmentId = 1;
            ////bill.AmountOfMoneyOwed = 200;

            ////Payment payment = new Payment();
            ////payment.PaymentId = 1;
            ////payment.ApartmentId = 1;
            ////payment.AmountOfMoneyToBePaid = 100;
            ////payment.ServicesToBePaid = "water";
            ////payment.Paid = "yes";

            ////WaterConsumption wCons = new WaterConsumption();
            ////wCons.WaterConsumptionId = 1;
            ////wCons.ApartmentId = 1;
            ////wCons.PricePerUnit = 20;
            ////wCons.Consumption = 10;
            ////wCons.AmountOfMoneyOwed = 200;

            ////RemainingDebt rd = new RemainingDebt();
            ////rd.RemainingDebtId = 1;
            ////rd.ApartmentId = 1;
            ////rd.Month = "March";
            ////rd.DebtTo = "Electricity";
            ////rd.AmountOfMoneyOwed = 70;

            ////apartment.Bills.Add(bill);
            ////apartment.Payments.Add(payment);
            ////apartment.WaterConsumptions.Add(wCons);
            ////apartment.RemainingDebts.Add(rd);
            #endregion
            //List<Apartment> apartmentList = new List<Apartment>();
            List<Apartment> apartmentList = GetApartments();
            
            return View(apartmentList);
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