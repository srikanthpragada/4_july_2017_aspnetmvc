using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }

    }
}