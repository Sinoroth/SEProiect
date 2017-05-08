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
        private const string WebServiceUrl = "http://localhost:55428/api/apartments";

        public async Task<List<Apartment>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<Apartment>>(json);

            return taskModels;
        }

        public async Task<Apartment> GetByIdAsync(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + id);

            var taskModels = JsonConvert.DeserializeObject<Apartment>(json);

            return taskModels;
        }

        public async Task<bool> PostAsync(Apartment a)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(a);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, Apartment a)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(a);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, Apartment a)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }



        public ActionResult List()
        {
            //GetAsync();
            Apartment apartment = new Apartment();
            apartment.ApartmentId = 1;
            apartment.ApartmentNumber = "ap.5(bl.E70)";
            apartment.UserId = 1;
            apartment.AmountOfMoneyOwed = 59;
            apartment.NumberOfOccupants = 3;

            List<Apartment> apartmentList = new List<Apartment>();

            return View(apartmentList);
        }

        //public ActionResult Create()
        //{
            
        //    PostAsync();
        //    return View();
        //}

        //public ActionResult Edit()
        //{
        //    PutAsync();
        //    return View();
        //}

        //public ActionResult Details()
        //{
        //    GetByIdAsync();
        //    return View();
        //}

        //public ActionResult Delete()
        //{
        //    DeleteAsync();
        //    return View();
        //}
    }
}