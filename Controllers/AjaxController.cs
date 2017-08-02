using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public string Now()
        {
            return DateTime.Now.ToString(); 
        }

        public string UserExists(string uname)
        {
            List<String> users = new List<string> { "Abc", "Bbc", "Xyz", "Pqr" };

            // check whether uname is already present 
            if (users.Contains(uname))
                return "yes";
            else
                return "no";
        }
    }
}