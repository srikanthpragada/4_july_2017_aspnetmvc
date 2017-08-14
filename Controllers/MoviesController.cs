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
        public ActionResult Index(string sortBy)
        {
            using (var ctx = new MoviesDbContext())
            {
                var movies = ctx.Movies.ToList();
                switch (sortBy)
                {
                    case "title": movies =  movies.OrderBy(m => m.Title).ToList(); break;
                    case "casting": movies = movies.OrderBy(m => m.Casting).ToList(); break;
                    case "lang": movies = movies.OrderBy(m => m.Lang).ToList(); break;
                    case "releasedOn": movies = movies.OrderBy(m => m.ReleasedOn).ToList(); break;
                    case "rating": movies = movies.OrderBy(m => m.Rating).ToList(); break;
                }
                
                return View(movies);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            Movie m = new Movie();
            m.ReleasedOn = DateTime.Today;
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
                    ModelState.Clear();
                    movie = new Movie();
                    movie.ReleasedOn = DateTime.Today;
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Sorry! Could not add movie due to error!";
            }
            return View(movie);

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                using (var ctx = new MoviesDbContext())
                {
                    var movie = ctx.Movies.Find(id);
                    if (movie == null)
                    {
                        ViewBag.Message = "Sorry! Movie not found!";
                        return View("showerror");
                    }
                    return View(movie);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry! Could not retrieve movie information due to error!";
                return View("showerror");
            }

            
        }

        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                using (var ctx = new MoviesDbContext())
                {
                    var dbmovie = ctx.Movies.Find(id);
                    if (dbmovie == null)
                    {
                        ViewBag.Message = "Sorry! Movie not found!";
                        return View("showerror");
                    }

                    // update db object
                    dbmovie.Title = movie.Title;
                    dbmovie.Casting = movie.Casting;
                    dbmovie.Rating = movie.Rating;
                    dbmovie.Lang = movie.Lang;
                    dbmovie.ReleasedOn = movie.ReleasedOn;

                    ctx.SaveChanges();
                    ViewBag.Message = "Movie has been updated succesfully!";
                    return View(movie);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry! Could not update moview due to error!";
            }

            return View(movie);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                using (var ctx = new MoviesDbContext())
                {
                    var movie = ctx.Movies.Find(id);
                    if (movie == null)
                    {
                        ViewBag.Message = "Sorry! Movie not found!";
                        return View("showerror");
                    }

                    ctx.Movies.Remove(movie);
                    ctx.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry! Could not retrieve movie information due to error!";
                return View("showerror");
            }


        }


        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string moviename)
        {
            using (var ctx = new MoviesDbContext())
            {
                var movies = from m in ctx.Movies
                             where m.Title.Contains(moviename)
                             select m;

                return PartialView("SearchResult", movies.ToList());
            }
        }

    }
}