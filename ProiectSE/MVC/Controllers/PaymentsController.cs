using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: Payments
        public ActionResult List()
        {
            Payment payment = new Payment();
            payment.PaymentId = 1;
            payment.ApartmentId = 1;
            payment.AmountOfMoneyToBePaid = 100;
            payment.ServicesToBePaid = "water";
            payment.Paid = "yes";

            List<Payment> paymentList = new List<Payment>();
            paymentList.Add(payment);

            return View(paymentList);
        }
    }
}