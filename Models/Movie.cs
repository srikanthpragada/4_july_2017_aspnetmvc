using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    [Table("Movies")]
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Casting { get; set; }

        [Required]
        public string Lang { get; set; }

        public DateTime ReleasedOn { get; set; }

        public int Rating { get; set; }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5}",
                 Id, Title, Casting, ReleasedOn, Lang, Rating);
        }

    }
}