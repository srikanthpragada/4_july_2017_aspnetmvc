using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new MoviesDbContext())
            {
                var movies = ctx.Movies.ToList();
                return View(movies);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            Movie m = new Movie();
            return View(m);
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            try
            {
                using (var ctx = new MoviesDbContext())
                {
                    ctx.Movies.Add(movie);
                    ctx.SaveChanges();
                    ViewBag.Message = "Movie has been added successfully!";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Sorry! Could not add movie due to error!";
            }
            return View(movie);

        }
    }
}