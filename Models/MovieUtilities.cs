using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Models
{
    public class MovieUtilities
    {
        public static List<SelectListItem> GetRatings()
        {
            var ratings = new List<SelectListItem>();

            ratings.Add(new SelectListItem { Text = "1" });
            ratings.Add(new SelectListItem { Text = "2" });
            ratings.Add(new SelectListItem { Text = "3" });
            ratings.Add(new SelectListItem { Text = "4" });
            ratings.Add(new SelectListItem { Text = "5" });

            return ratings; 
        }

        public static List<SelectListItem> GetLanguages()
        {
            var langs = new List<SelectListItem>();

            langs.Add(new SelectListItem { Text = "English", Value ="e" });
            langs.Add(new SelectListItem { Text = "Hindi", Value = "h" });
            langs.Add(new SelectListItem { Text = "Telugu", Value = "t" });
            return langs;
        }


        public static string GetRatingString(int rating)
        {
            string s = "*";

            for (int i = 2; i <= rating; i++)
                s += "*";

            return s; 
        }

        public static string GetLanguage(string lang)
        {
            switch(lang)
            {
                case "e": return "English";
                case "h": return "Hindi";
                case "t": return "Telugu";
                default: return "Unknown";
            }
        }
    }
}