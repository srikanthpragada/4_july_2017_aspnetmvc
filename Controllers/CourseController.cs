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

        [HttpGet]
        public ActionResult Calculate()
        {
            CourseViewModel model = new CourseViewModel();
            model.Timings = "e";
            return View(model);
        }

        [HttpPost]
        public ActionResult Calculate(CourseViewModel model)
        {

            // Request.Form["timings"]

            int fee = Int32.Parse(model.CourseFee);

            if (model.Timings == "m")
                fee = fee * 90 /100;
            else
                if( model.Timings == "a")
                   fee = fee * 80 / 100;

            if (model.CourseMaterial)
                fee += 500;

            ViewBag.Fee = fee;

            return View(model);
        }

    }
}