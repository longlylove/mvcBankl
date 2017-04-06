using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //** Throwing a stackoverflow exception
            //throw new StackOverflowException();
            
            
            //return PartialView();
            return View();
        }

        public ActionResult About()
        {
            //ViewBag: dynamic or session object to pass the data from controller to view
            //ViewBag: object is disposed as soon as your view is rendered
            //ViewBag: after redirect, any property set will be lost
            //Something would survive the redirect -> use the TempData[] dictionary
            ViewBag.Message = ":P.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = "Got your msg.";

            return View();
        }

        public ActionResult Foo()
        {
            //calling Views will make the view engine to go and look for a view called FOO
            //--  return View();

            // This will return an alias of the About page 
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            const string serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            //return Content(serial);
            //return new HttpStatusCodeResult(403);

            //to return json-data, request permission needs to be explicitly set to allow Get request
            //return Json(new {name = "serial", value = serial}, JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
        }
    }
}