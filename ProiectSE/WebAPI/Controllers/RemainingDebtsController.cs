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
    public class RemainingDebtsController : ApiController
    {
        private OwnersAssociationContext db = new OwnersAssociationContext();

        // GET: api/RemainingDebts
        public IQueryable<RemainingDebt> GetRemainingDebts()
        {
            return db.RemainingDebts;
        }

        // GET: api/RemainingDebts/5
        [ResponseType(typeof(RemainingDebt))]
        public IHttpActionResult GetRemainingDebt(int id)
        {
            RemainingDebt remainingDebt = db.RemainingDebts.Find(id);
            if (remainingDebt == null)
            {
                return NotFound();
            }

            return Ok(remainingDebt);
        }

        // PUT: api/RemainingDebts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRemainingDebt(int id, RemainingDebt remainingDebt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != remainingDebt.RemainingDebtId)
            {
                return BadRequest();
            }

            db.Entry(remainingDebt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemainingDebtExists(id))
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

        // POST: api/RemainingDebts
        [ResponseType(typeof(RemainingDebt))]
        public IHttpActionResult PostRemainingDebt(RemainingDebt remainingDebt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RemainingDebts.Add(remainingDebt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = remainingDebt.RemainingDebtId }, remainingDebt);
        }

        // DELETE: api/RemainingDebts/5
        [ResponseType(typeof(RemainingDebt))]
        public IHttpActionResult DeleteRemainingDebt(int id)
        {
            RemainingDebt remainingDebt = db.RemainingDebts.Find(id);
            if (remainingDebt == null)
            {
                return NotFound();
            }

            db.RemainingDebts.Remove(remainingDebt);
            db.SaveChanges();

            return Ok(remainingDebt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RemainingDebtExists(int id)
        {
            return db.RemainingDebts.Count(e => e.RemainingDebtId == id) > 0;
        }
    }
}