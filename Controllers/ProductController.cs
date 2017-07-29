using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class ProductController : Controller
    {
         
        public ActionResult Index()
        {
            List<Product> prods = new List<Product>();
            using (SqlConnection con = new SqlConnection(
                @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=msdb;Integrated Security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from products", con);
                SqlDataReader dr = cmd.ExecuteReader();
             
                while (dr.Read())
                {
                    prods.Add(new Product
                       {
                         ProdName = dr["prodname"].ToString(),
                         Price = Double.Parse(dr["price"].ToString())
                       }
                     );
                }
            }

            return View(prods);

        }
    }
}