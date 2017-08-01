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
        [OutputCache(Duration = 60)]
        public ActionResult Index(int price)
        {
            ViewBag.CreatedOn = DateTime.Now.ToLongTimeString(); 
            List<Product> prods = new List<Product>();
            using (SqlConnection con = new SqlConnection(
                @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=msdb;Integrated Security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from products where price >=" + price, con);
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

        [HttpGet]
        public ActionResult Update()
        {
            UpdateViewModel model = new UpdateViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // update 
                ViewBag.Message = String.Format("Update product {0} with price {1} successfully!", model.ProdId, model.NewPrice);
            }
            else
                ViewBag.Message = "";

            return View(model);
        }
    }
}