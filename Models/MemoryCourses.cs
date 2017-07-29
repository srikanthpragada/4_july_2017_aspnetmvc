using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class MemoryCourses
    {

        static List<Course> courses = new List<Course>() {
                new Course { Id = 1, Name = "Java SE", Duration = 40, Price = 5000},
                new Course { Id = 2, Name = "Angular", Duration = 15, Price = 2000},
                new Course { Id = 3, Name = "Java EE", Duration = 40, Price = 6000},
                new Course { Id = 4, Name = "Oracle Database", Duration = 30, Price = 3500}

       };


        static public List<Course> Courses
        {
            get
            {
                return courses;
            }
        }
    }
}