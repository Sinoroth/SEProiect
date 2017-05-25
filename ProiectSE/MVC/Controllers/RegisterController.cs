using Data.Model;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public bool PostUser(User u)
        {
            RestClient<User> rc = new RestClient<User>();
            rc.WebServiceUrl = "http://localhost:55428/api/users/";
            bool response = rc.PostAsync(u);
            return response;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User u)
        {

            PostUser(u);
            return View();
        }


    }
}