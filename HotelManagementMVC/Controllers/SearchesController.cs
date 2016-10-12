using System.Web.Mvc;
using HotelManagementWebAPI;
using System.Collections.Generic;
using HotelManagementWebAPI.Models;

namespace HotelManagementWebAPI.Controllers
{
    public class SearchesController : Controller
    {
        // GET: Searches
        public ActionResult SearchHotel()
        {
            Search search = new Search(); 
            return View(search);
        }
        [HttpPost]
        public ActionResult SearchHotel(Search _search)
        {
            return RedirectToAction("DisplayHotel", "HotelDisplay", new { search = _search});
        }
    }
}