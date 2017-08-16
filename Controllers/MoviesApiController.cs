using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}