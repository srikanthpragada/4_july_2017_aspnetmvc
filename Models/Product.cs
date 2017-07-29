using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public double Price { get; set; }
        public int Qoh { get; set; }
        public string Remarks { get; set; }
        public string Catcode { get; set; }
    }
}