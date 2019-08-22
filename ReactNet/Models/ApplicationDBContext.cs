using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactNet.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PostgreSqlReactDb;Username=postgres;Password=123");

    }

    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Note { get; set; }

    }
}

//Intial Migration created with error:
//An error occurred while accessing the IWebHost on class 'Program'. Continuing without the application service provider. Error: AddDbContext was called with configuration, but the context type 'ApplicationDBContext' only declares a parameterless constructor. This means that the configuration passed to AddDbContext will never be used. If configuration is passed to AddDbContext, then 'ApplicationDBContext' should declare a constructor that accepts a DbContextOptions<ApplicationDBContext> and must pass it to the base constructor for DbContext.