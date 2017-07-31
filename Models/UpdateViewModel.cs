using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class UpdateViewModel
    {
        [Range (1,1000, ErrorMessage = "Invaid product id!")]
        public int ProdId { get; set; }

        [Range(1, Double.MaxValue , ErrorMessage = "Invalid Price!")]
        public double NewPrice { get; set; }
    }
}