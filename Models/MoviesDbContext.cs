using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class MoviesDbContext : DbContext 
    {
        public MoviesDbContext() : base("name=localdb")
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}