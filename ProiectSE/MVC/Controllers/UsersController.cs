using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult List()
        {
            User user = new User();
            user.UserId = 1;
            user.Name = "Stancu ALex";
            user.Email = "ex@gmail.com";
            user.PhoneNumber = "045";
            user.Password = "pass";
            user.Role = "user";
            List<User> userList = new List<User>();
            userList.Add(user);
            return View(userList);
        }

        public ActionResult Details()
        {
            User user = new User();
            user.UserId = 1;
            user.Name = "Stancu ALex";
            user.Email = "ex@gmail.com";
            user.PhoneNumber = "045";
            user.Password = "pass";
            user.Role = "user";
            //List<User> userList = new List<User>();
            //userList.Add(user);
            return View(user);
        }
    }

}