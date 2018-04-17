using GameRetailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GameRetailer.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private GameRetailerEntities db = new GameRetailerEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contacts()
        {
            return View();
        }
    }
}
