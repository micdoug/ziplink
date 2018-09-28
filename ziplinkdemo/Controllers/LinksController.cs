using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ziplinkdemo.Models;

namespace ziplinkdemo.Controllers
{
    public class LinksController : Controller
    {
        public ActionResult List(string filtro = null)
        {
            using (Database database = new Database())
            {
                if (filtro == null)
                {
                    var links = database.Links.OrderBy(x => x.Url).ToList();
                    return View(links);
                }
                else
                {
                    var links = database.Links.Where(x => x.Description.StartsWith(filtro) || x.Url.StartsWith(filtro))
                        .OrderBy(x => x.Url).ToList();
                    return View(links);
                }
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Remove()
        {
            return View();
        }

        public ActionResult Enable()
        {
            return View();
        }

        public ActionResult Disable()
        {
            return View();
        }

        public ActionResult Go()
        {
            return View();
        }
    }
}