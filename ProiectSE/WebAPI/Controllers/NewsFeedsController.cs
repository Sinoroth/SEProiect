using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class NewsFeedsController : ApiController
    {
        private OwnersAssociationContext db = new OwnersAssociationContext();

        // GET: api/NewsFeeds
        public IQueryable<NewsFeed> GetNewsFeeds()
        {
            return db.NewsFeeds;
        }

        // GET: api/NewsFeeds/5
        [ResponseType(typeof(NewsFeed))]
        public IHttpActionResult GetNewsFeed(int id)
        {
            NewsFeed newsFeed = db.NewsFeeds.Find(id);
            if (newsFeed == null)
            {
                return NotFound();
            }

            return Ok(newsFeed);
        }

        // PUT: api/NewsFeeds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewsFeed(int id, NewsFeed newsFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsFeed.NewsFeedId)
            {
                return BadRequest();
            }

            //db.Entry(newsFeed).State = EntityState.Modified;
            NewsFeed nf = db.NewsFeeds.Find(newsFeed.NewsFeedId);
            nf.News = newsFeed.News;
            nf.Date = newsFeed.Date;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsFeedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NewsFeeds
        [ResponseType(typeof(NewsFeed))]
        public IHttpActionResult PostNewsFeed(NewsFeed newsFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsFeeds.Add(newsFeed);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newsFeed.NewsFeedId }, newsFeed);
        }

        // DELETE: api/NewsFeeds/5
        [ResponseType(typeof(NewsFeed))]
        public IHttpActionResult DeleteNewsFeed(int id)
        {
            NewsFeed newsFeed = db.NewsFeeds.Find(id);
            if (newsFeed == null)
            {
                return NotFound();
            }

            db.NewsFeeds.Remove(newsFeed);
            db.SaveChanges();

            return Ok(newsFeed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsFeedExists(int id)
        {
            return db.NewsFeeds.Count(e => e.NewsFeedId == id) > 0;
        }
    }
}