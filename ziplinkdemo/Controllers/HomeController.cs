using System;
using System.Collections.Generic;
using ziplinkdemo.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ziplinkdemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}