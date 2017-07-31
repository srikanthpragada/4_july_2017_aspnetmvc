using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CourseController : Controller
    {
        
        public ActionResult Index()
        {
          
            return View(MemoryCourses.Courses);
        }

       

        public ActionResult Details(int id)
        {
            Course course = null; 
            // get course with the given id 
            foreach(Course c in MemoryCourses.Courses)
            {
                if (c.Id == id)
                {
                    course = c;
                    break;
                }
            }

            return View(course);
        }
    }
}