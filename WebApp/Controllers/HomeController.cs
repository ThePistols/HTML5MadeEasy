using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Section1Index()
        {
            return View("Section1/index");
        }

        public ActionResult Section2Index()
        {
            return View("Section2/index");
        }

        public ActionResult Section3Index()
        {
            return View("Section3/index");
        }

        public ActionResult AdminIndex()
        {
            return View("Admin/index");
        }



    }
}