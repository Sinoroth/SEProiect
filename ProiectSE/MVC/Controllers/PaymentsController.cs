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

        public bool DeletePayment(int id, Payment p)
        {
            RestClient<Payment> rc = new RestClient<Payment>();
            rc.WebServiceUrl = "http://localhost:55428/api/payments/";
            bool response = rc.DeleteAsync(id, p);
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
                    foreach (var payment in apartment.Payments)
                    {
                        paymentList.Add(payment);
                    }
                }
                return View(paymentList);
            }
            else
            {
                List<Payment> paymentList = new List<Payment>();

                return View(paymentList);
            }

        
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}