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
    public class WaterConsumptionsController : ApiController
    {
        private OwnersAssociationContext db = new OwnersAssociationContext();

        // GET: api/WaterConsumptions
        public IQueryable<WaterConsumption> GetWaterConsumptions()
        {
            return db.WaterConsumptions;
        }

        // GET: api/WaterConsumptions/5
        [ResponseType(typeof(WaterConsumption))]
        public IHttpActionResult GetWaterConsumption(int id)
        {
            WaterConsumption waterConsumption = db.WaterConsumptions.Find(id);
            if (waterConsumption == null)
            {
                return NotFound();
            }

            return Ok(waterConsumption);
        }

        // PUT: api/WaterConsumptions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWaterConsumption(int id, [FromBody]WaterConsumption waterConsumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != waterConsumption.WaterConsumptionId)
            {
                return BadRequest();
            }

            //db.Entry(waterConsumption).State = EntityState.Modified;
            WaterConsumption wc = db.WaterConsumptions.Find(waterConsumption.WaterConsumptionId);
            wc.Consumption = waterConsumption.Consumption;
            wc.PricePerUnit = waterConsumption.PricePerUnit;
            wc.AmountOfMoneyOwed = waterConsumption.AmountOfMoneyOwed;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterConsumptionExists(id))
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

        // POST: api/WaterConsumptions
        [ResponseType(typeof(WaterConsumption))]
        public IHttpActionResult PostWaterConsumption(WaterConsumption waterConsumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WaterConsumptions.Add(waterConsumption);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = waterConsumption.WaterConsumptionId }, waterConsumption);
        }

        // DELETE: api/WaterConsumptions/5
        [ResponseType(typeof(WaterConsumption))]
        public IHttpActionResult DeleteWaterConsumption(int id)
        {
            WaterConsumption waterConsumption = db.WaterConsumptions.Find(id);
            if (waterConsumption == null)
            {
                return NotFound();
            }

            db.WaterConsumptions.Remove(waterConsumption);
            db.SaveChanges();

            return Ok(waterConsumption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WaterConsumptionExists(int id)
        {
            return db.WaterConsumptions.Count(e => e.WaterConsumptionId == id) > 0;
        }
    }
}