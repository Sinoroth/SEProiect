using MVC.Models;
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
        public ActionResult List()
        {
            NewsFeed newsFeed = new NewsFeed();
            newsFeed.NewsFeedId = 1;
            newsFeed.Date = new DateTime(2008, 1, 2, 6, 30, 15);
            newsFeed.News = "Something";

            List<NewsFeed> newsFeedList = new List<NewsFeed>();

            newsFeedList.Add(newsFeed);

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

    }
}
