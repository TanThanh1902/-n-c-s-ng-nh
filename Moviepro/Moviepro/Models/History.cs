using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moviepro.Models
{
    public class History
    {
        public int IDFilm { get; set; }
        public string FilmName { get; set; }
        public string Image { get; set; }
        public Nullable<double> Rating { get; set; }
        public int Votes { get; set; }
        public Nullable<System.DateTime> DateSubmited { get; set; }
    }
}