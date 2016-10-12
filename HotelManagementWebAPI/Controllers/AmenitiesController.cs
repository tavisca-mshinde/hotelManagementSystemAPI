using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HotelManagementWebAPI.Database;

namespace HotelManagementWebAPI.Controllers
{
    public class AmenitiesController : ApiController
    {
        private HotelManagementSystemEntities db = new HotelManagementSystemEntities();

        // GET: api/Amenities
        public IQueryable<Amenity> GetAmenities()
        {
            return db.Amenities;
        }

        // GET: api/Amenities/5
        [ResponseType(typeof(Amenity))]
        public async Task<IHttpActionResult> GetAmenity(byte id)
        {
            Amenity amenity = await db.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }

            return Ok(amenity);
        }

        // PUT: api/Amenities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAmenity(byte id, Amenity amenity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amenity.AmenityId)
            {
                return BadRequest();
            }

            db.Entry(amenity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(id))
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

        // POST: api/Amenities
        [ResponseType(typeof(Amenity))]
        public async Task<IHttpActionResult> PostAmenity(Amenity amenity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Amenities.Add(amenity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = amenity.AmenityId }, amenity);
        }

        // DELETE: api/Amenities/5
        [ResponseType(typeof(Amenity))]
        public async Task<IHttpActionResult> DeleteAmenity(byte id)
        {
            Amenity amenity = await db.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }

            db.Amenities.Remove(amenity);
            await db.SaveChangesAsync();

            return Ok(amenity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AmenityExists(byte id)
        {
            return db.Amenities.Count(e => e.AmenityId == id) > 0;
        }
    }
}