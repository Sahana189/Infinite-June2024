using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MoviesPrj.Models
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
    }
}