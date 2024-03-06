using EpiDHL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiDHL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Cliente cliente = new Cliente();
            ViewBag.Cliente = cliente;
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
    }
}