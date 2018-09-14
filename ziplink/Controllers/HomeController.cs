using System;
using System.Linq;
using System.Web.Mvc;
using ziplink.Infrastructure;
using ziplink.Models;

namespace ziplink.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            Link link = null;
            using (DatabaseContext db = new DatabaseContext())
            {
                link = db.Links.Find(1);
                //link.Visited += 1;
                //db.SaveChanges();
                //db.Entry(link).State = System.Data.Entity.EntityState.Modified;
                //db.SaveChanges();
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                link.Visited += 1;
                db.Links.Add(link);
                db.SaveChanges();
            }
            return "Hello World";
        }
    }
}