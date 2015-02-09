using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterestFinder.Models;

namespace InterestFinder.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "InterestFinder, helping people find new interests since 2014";
            ViewBag.NumberOfUsers = ApplicationInformation.TotalUsers;
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


    }
}