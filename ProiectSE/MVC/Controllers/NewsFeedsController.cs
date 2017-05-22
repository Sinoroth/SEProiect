using MVC.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class NewsFeedsController : Controller
    {
        // GET: NewsFeeds
        public List<NewsFeed> GetNewsFeeds()
        {
            RestClient<NewsFeed> rc = new RestClient<NewsFeed>();
            rc.WebServiceUrl = "http://localhost:55428/api/newsfeeds/";
            var newsFeedList = rc.GetAsync();
            return newsFeedList;
        }

        public NewsFeed GetNewsFeedById(int id)
        {
            RestClient<NewsFeed> rc = new RestClient<NewsFeed>();
            rc.WebServiceUrl = "http://localhost:55428/api/newsfeeds/";
            var newsFeed = rc.GetByIdAsync(id);
            return newsFeed;
        }

        public bool PostNewsFeed(NewsFeed nf)
        {
            RestClient<NewsFeed> rc = new RestClient<NewsFeed>();
            rc.WebServiceUrl = "http://localhost:55428/api/newsfeeds/";
            bool response = rc.PostAsync(nf);
            return response;
        }

        public bool PutNewsFeed(int id, NewsFeed nf)
        {
            RestClient<NewsFeed> rc = new RestClient<NewsFeed>();
            rc.WebServiceUrl = "http://localhost:55428/api/newsfeeds/";
            bool response = rc.PutAsync(id, nf);
            return response;
        }

        public bool DeleteNewsFeed(int id)
        {
            RestClient<NewsFeed> rc = new RestClient<NewsFeed>();
            rc.WebServiceUrl = "http://localhost:55428/api/newsfeeds/";
            bool response = rc.DeleteAsync(id);
            return response;
        }

        public ActionResult List()
        {
            //NewsFeed newsFeed = new NewsFeed();
            //newsFeed.NewsFeedId = 1;
            //newsFeed.Date = new DateTime(2008, 1, 2, 6, 30, 15);
            //newsFeed.News = "Something";

            //List<NewsFeed> newsFeedList = new List<NewsFeed>();

            //newsFeedList.Add(newsFeed);
            List<NewsFeed> newsFeedList = GetNewsFeeds();
            return View(newsFeedList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.NewsFeed nf)
        {

            PostNewsFeed(nf);
            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {

            NewsFeed nf = GetNewsFeedById(id);

            return View(nf);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.NewsFeed nf)
        {

            PutNewsFeed(nf.NewsFeedId, nf);
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            NewsFeed nf = GetNewsFeedById(id);
            return View(nf);
        }


        public ActionResult Delete(int id)
        {
            NewsFeed nf = GetNewsFeedById(id);
            return View(nf);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeleteNewsFeed(id);
            return RedirectToAction("List");

        }


    }
}
