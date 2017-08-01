using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Models
{
    public class CourseViewModel
    {
        public static List<SelectListItem> Courses = new List<SelectListItem>
        {
            new SelectListItem { Text = "Java Langauge", Value = "5000"},
            new SelectListItem { Text = "Oracle Database", Value = "4000"},
            new SelectListItem { Text = "Android Programming", Value = "6000"}
        };

        public string CourseFee { get; set; }
        public string Timings { get; set; }
        public Boolean CourseMaterial { get; set; }

    }
}