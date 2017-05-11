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

        public bool DeleteNewsFeed(int id, NewsFeed nf)
        {
            RestClient<NewsFeed> rc = new RestClient<NewsFeed>();
            rc.WebServiceUrl = "http://localhost:55428/api/newsfeeds/";
            bool response = rc.DeleteAsync(id, nf);
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

        public ActionResult Details()
        {
            NewsFeed newsFeed = new NewsFeed();
            newsFeed.NewsFeedId = 1;
            newsFeed.Date = new DateTime(2008, 1, 2, 6, 30, 15);
            newsFeed.News = "Something";

            //List<NewsFeed> newsFeedList = new List<NewsFeed>();

            //newsFeedList.Add(newsFeed);

            return View(newsFeed);
        }

        public ActionResult Create()
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

    }
}
