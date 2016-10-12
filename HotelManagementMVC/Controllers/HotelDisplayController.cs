using HotelManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVC.Controllers
{
    public class HotelDisplayController : Controller
    {
        // GET: HotelDisplay
        public ActionResult DisplayHotel(Search search)
        {
            return View(search);
        }
    }
}