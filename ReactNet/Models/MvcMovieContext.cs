using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReactNet.Models
{
    public class MvcMovieContext : DbContext
    {
        //public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Movie> Movie { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PostgreSqlDemoDb;Username=postgres;Password=123");
       
    }

    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        //public string Note { get; set; }

    }
}
