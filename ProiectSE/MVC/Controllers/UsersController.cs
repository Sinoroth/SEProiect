using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Web.Security;
using Plugin.RestClient;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public List<User> GetUsers()
        {
            RestClient<User> rc = new RestClient<User>();
            rc.WebServiceUrl = "http://localhost:55428/api/users/";
            var userList = rc.GetAsync();
            return userList;
        }

        public User GetUserById(int id)
        {
            RestClient<User> rc = new RestClient<User>();
            rc.WebServiceUrl = "http://localhost:55428/api/users/";
            var user = rc.GetByIdAsync(id);
            return user;
        }

        public List<User> GetUserByEmail(string email)
        {
            RestClient<User> rc = new RestClient<User>();
            rc.WebServiceUrl = "http://localhost:55428/api/users/email/";
            var user = rc.GetByEmailAsync(email);
            return user;
        }

        public bool PostUser(User u)
        {
            RestClient<User> rc = new RestClient<User>();
            rc.WebServiceUrl = "http://localhost:55428/api/users/";
            bool response = rc.PostAsync(u);
            return response;
        }

        public bool PutUser(int id, User u)
        {
            RestClient<User> rc = new RestClient<User>();
            rc.WebServiceUrl = "http://localhost:55428/api/users/";
            bool response = rc.PutAsync(id, u);
            return response;
        }

        public bool DeleteUser(int id, User u)
        {
            RestClient<User> rc = new RestClient<User>();
            rc.WebServiceUrl = "http://localhost:55428/api/users/";
            bool response = rc.DeleteAsync(id, u);
            return response;
        }

        public bool IsValid(string email, string pass)
        {
            List<User> user = new List<User>();
            user = GetUserByEmail(email);
            if (user == null)
                return false;
            else if(user[0].Password == pass)
            {
                return true;
            }
            else
                return false;
        }

        public ActionResult List()
        {
            //User user = new User();
            //user.UserId = 1;
            //user.Name = "Stancu ALex";
            //user.Email = "ex@gmail.com";
            //user.PhoneNumber = "045";
            //user.Password = "pass";
            //user.Role = "user";
            //List<User> userList = new List<User>();
            //userList.Add(user);
            List<User> userList = GetUsers();
            return View(userList);
        }

        public ActionResult Details()
        {
            //User user = new User();
            //user.UserId = 1;
            //user.Name = "Stancu ALex";
            //user.Email = "ex@gmail.com";
            //user.PhoneNumber = "045";
            //user.Password = "pass";
            //user.Role = "user";
            //List<User> userList = new List<User>();
            //userList.Add(user);
            //User user = new Models.User();
            
            //user = GetUserById(user.UserId);

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Name, true);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(Models.User user)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Users");
        }
    }

}
