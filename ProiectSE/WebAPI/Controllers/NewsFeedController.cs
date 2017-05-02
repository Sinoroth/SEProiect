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
    public class NewsFeedController : ApiController
    {
        private OwnersAssociationContext db = new OwnersAssociationContext();

        // GET: api/NewsFeed
        public IQueryable<NewsFeed> GetNewsFeed()
        {
            return db.NewsFeed;
        }

        // GET: api/NewsFeed/5
        [ResponseType(typeof(NewsFeed))]
        public IHttpActionResult GetNewsFeed(int id)
        {
            NewsFeed newsFeed = db.NewsFeed.Find(id);
            if (newsFeed == null)
            {
                return NotFound();
            }

            return Ok(newsFeed);
        }

        // PUT: api/NewsFeed/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewsFeed(int id, NewsFeed newsFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsFeed.NewsId)
            {
                return BadRequest();
            }

            db.Entry(newsFeed).State = EntityState.Modified;

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

        // POST: api/NewsFeed
        [ResponseType(typeof(NewsFeed))]
        public IHttpActionResult PostNewsFeed(NewsFeed newsFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsFeed.Add(newsFeed);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newsFeed.NewsId}, newsFeed);
        }

        // DELETE: api/NewsFeed/5
        [ResponseType(typeof(NewsFeed))]
        public IHttpActionResult DeleteNewsFeed(int id)
        {
            NewsFeed newsFeed = db.NewsFeed.Find(id);
            if (newsFeed == null)
            {
                return NotFound();
            }

            db.NewsFeed.Remove(newsFeed);
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
            return db.NewsFeed.Count(e => e.NewsId == id) > 0;
        }
    }
}
