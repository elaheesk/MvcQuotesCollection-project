using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcQuotesCollection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "First application with MVC Asp.Net";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please contact me by my e-mail or phonenumber";

            return View();
        }
    }
}