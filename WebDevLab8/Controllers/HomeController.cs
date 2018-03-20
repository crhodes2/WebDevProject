using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDevProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Appt()
        {
            ViewBag.Message = "Please fill out this form below to set up an appointment with our specialist, Nurse Joy.";

            return View();
        }

        public ActionResult Groom()
        {
            ViewBag.Message = "Grooming";

            return View();
        }

        public ActionResult Nutrition()
        {
            ViewBag.Message = "Nutrition";

            return View();
        }

        public ActionResult Success()
        {
            ViewBag.Message = "Thank you";

            return View();
        }

        public ActionResult Health()
        {
            ViewBag.Message = "Your Pokemon's health is very important to us";

            return View();
        }
        public ActionResult Pest()
        {
            ViewBag.Message = "Get rid of pests for good";

            return View();
        }
    }
}