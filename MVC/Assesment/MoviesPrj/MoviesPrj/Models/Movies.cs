using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MoviesPrj.Models
{
    public class Movies
    {
        [Key]
        public int Mid { get; set; }

        public string Moviename { get; set; }

        [Display(Name = "Release Date")]
        public DateTime DateofRelease { get; set; }
    }
}