using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class SessionController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(string name)
        {
            if (name == null || name.Length == 0)
                return View();
            
            SortedSet<string> names = Session["names"] as SortedSet<string>;
            if(names == null)
            {
                names = new SortedSet<string>();
                Session.Add("names", names);
            }
            names.Add(name);

            return View(); 
        }


    }
}