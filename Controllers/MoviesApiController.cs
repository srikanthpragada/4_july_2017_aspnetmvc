using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mvcdemo
{
    public class MoviesApiController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            using (var ctx = new MoviesDbContext())
            {
                var movies = ctx.Movies.ToList();
                return movies; 
            }
        }

        // GET api/<controller>/5
        public Movie Get(int id)
        {
            using (var ctx = new MoviesDbContext())
            {
                var movie = (from m in ctx.Movies
                            where m.Id == id
                            select m).SingleOrDefault();

                if (movie != null)
                    return movie;
                else
                {
                    HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.NotFound);
                    throw new HttpResponseException(msg);
                }
            }

        }

        // POST api/<controller>
        public void Post(Movie movie)
        {
            try
            {
                HttpContext.Current.Trace.Write("Movie " + movie.ToString());
                using (var ctx = new MoviesDbContext())
                {
                    ctx.Movies.Add(movie);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Write("Error in MoviesApiController.Post : " +
                    ex.Message);
                if ( ex.InnerException != null)
                    HttpContext.Current.Trace.Write
                        ("Inner Exception : " +  ex.InnerException.Message);

                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            
        }

        // PUT api/<controller>/5
        public void Put(int id,Movie movie)
        {
            try
            {
                using (var ctx = new MoviesDbContext())
                {
                    var dbmovie = ctx.Movies.Find(id);
                    if (dbmovie == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    // update db object
                    dbmovie.Title = movie.Title;
                    dbmovie.Casting = movie.Casting;
                    dbmovie.Rating = movie.Rating;
                    dbmovie.Lang = movie.Lang;
                    dbmovie.ReleasedOn = movie.ReleasedOn;

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Write("Error in MoviesApiController.Put : " + ex.Message);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            try
            {
                using (var ctx = new MoviesDbContext())
                {
                    var movie = ctx.Movies.Find(id);
                    if (movie == null)
                        throw new HttpResponseException(HttpStatusCode.NotFound);

                    ctx.Movies.Remove(movie);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Write("Error in MoviesApiController.Delete : " + ex.Message);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }


        }
    }
}