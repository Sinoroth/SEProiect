using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using Plugin.RestClient;

namespace MVC.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: Payments
        public List<Payment> GetPayments()
        {
            RestClient<Payment> rc = new RestClient<Payment>();
            rc.WebServiceUrl = "http://localhost:55428/api/payments/";
            var paymentList = rc.GetAsync();
            return paymentList;
        }

        public Payment GetPaymentById(int id)
        {
            RestClient<Payment> rc = new RestClient<Payment>();
            rc.WebServiceUrl = "http://localhost:55428/api/payments/";
            var payment = rc.GetByIdAsync(id);
            return payment;
        }

        public bool PostPayment(Payment p)
        {
            RestClient<Payment> rc = new RestClient<Payment>();
            rc.WebServiceUrl = "http://localhost:55428/api/payments/";
            bool response = rc.PostAsync(p);
            return response;
        }

        public bool PutPayment(int id, Payment p)
        {
            RestClient<Payment> rc = new RestClient<Payment>();
            rc.WebServiceUrl = "http://localhost:55428/api/payments/";
            bool response = rc.PutAsync(id, p);
            return response;
        }

        public bool DeletePayment(int id)
        {
            RestClient<Payment> rc = new RestClient<Payment>();
            rc.WebServiceUrl = "http://localhost:55428/api/payments/";
            bool response = rc.DeleteAsync(id);
            return response;
        }

        public ActionResult List()
        {
            //Payment payment = new Payment();
            //payment.PaymentId = 1;
            //payment.ApartmentId = 1;
            //payment.AmountOfMoneyToBePaid = 100;
            //payment.ServicesToBePaid = "water";
            //payment.Paid = "yes";

            //List<Payment> paymentList = new List<Payment>();
            //paymentList.Add(payment);
            UsersController uc = new UsersController();
            string email = Request.Cookies["UserCookie"].Value;
            List<User> user = new List<User>();
            user = uc.GetUserByEmail(email);
            if (user[0].Role == "user")
            {
                List<Payment> paymentList = new List<Payment>();
                foreach (var apartment in user[0].Apartments)
                {
                    foreach (var p in apartment.Payments)
                    {
                        paymentList.Add(p);
                    }
                }
                return View(paymentList);
            }
            else
            {
                List<Payment> paymentList = GetPayments();
                return View(paymentList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Payment p)
        {

            PostPayment(p);
            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {

            Payment p = GetPaymentById(id);

            return View(p);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Payment p)
        {

            PutPayment(p.PaymentId, p);
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            Payment p = GetPaymentById(id);

            return View(p);
        }


        public ActionResult Delete(int id)
        {
            Payment p = GetPaymentById(id);
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeletePayment(id);
            return RedirectToAction("List");

        }

    }
}