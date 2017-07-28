using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            ViewBag.Today = DateTime.Now;
            return View();
        }

        public ActionResult Info()
        {
           var person = new Person { Name = "Scott", Email = "scott@microsoft.com" };
           return View(person);
        }


        public ActionResult Wish(string name)
        {
            string message = "Good Evening";

            if (name == null)
                name = "Mr. Unknown";

            int hour = DateTime.Now.Hour;
            if (hour < 12)
                message = "Good Morning";
            else
                if (hour < 17)
                message = "Good Afternoon";

            ViewBag.Message = message + ", " + name;
            return View();
        }
    }
}