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
    public class HotelsController : ApiController
    {
        private HotelManagementSystemEntities db = new HotelManagementSystemEntities();

        // GET: api/Hotels
        public IQueryable<Hotel> GetHotels()
        {
            return db.Hotels;
        }

        //// GET: api/Hotels/5
        //[ResponseType(typeof(Hotel))]
        //public async Task<IHttpActionResult> GetHotel(string id)
        //{
        //    Hotel hotel = await db.Hotels.FindAsync(id);
        //    if (hotel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(hotel);
        //}

        //GET: api/Hotels/Mumbai
        [ResponseType(typeof(Hotel))]
        public List<Hotel> GetHotel(string city)
        {
            List<Hotel> hotels = db.Hotels.Where(x => x.City == city).Include(a=>a.Address).ToList();
            
            if (hotels == null)
            {
                throw new  HttpResponseException(HttpStatusCode.NotFound);
            }

            return hotels;
        }





        // PUT: api/Hotels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHotel(string id, Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel.HotelCode)
            {
                return BadRequest();
            }

            db.Entry(hotel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        [ResponseType(typeof(Hotel))]
        public async Task<IHttpActionResult> PostHotel(Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hotels.Add(hotel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelExists(hotel.HotelCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hotel.HotelCode }, hotel);
        }

        // DELETE: api/Hotels/5
        [ResponseType(typeof(Hotel))]
        public async Task<IHttpActionResult> DeleteHotel(string id)
        {
            Hotel hotel = await db.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            db.Hotels.Remove(hotel);
            await db.SaveChangesAsync();

            return Ok(hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelExists(string id)
        {
            return db.Hotels.Count(e => e.HotelCode == id) > 0;
        }
    }
}