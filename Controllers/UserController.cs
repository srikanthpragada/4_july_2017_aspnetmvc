using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string pwd)
        {
            if ( pwd == "admin")
            {
                FormsAuthentication.RedirectFromLoginPage("admin", false);
            }
            ViewBag.Message = "Sorry! Invalid Password!";
            return View();
        }
    }
}