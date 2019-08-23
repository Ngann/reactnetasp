using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReactNet.Models;

namespace ReactNet.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=reactdb;Username=postgres;Password=123");


        public DbSet<WeatherForecast> WeatherForecast { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Student> Student { get; set; }

    }
}

//Intial Migration created with error:
//An error occurred while accessing the IWebHost on class 'Program'. Continuing without the application service provider. Error: AddDbContext was called with configuration, but the context type 'ApplicationDBContext' only declares a parameterless constructor. This means that the configuration passed to AddDbContext will never be used. If configuration is passed to AddDbContext, then 'ApplicationDBContext' should declare a constructor that accepts a DbContextOptions<ApplicationDBContext> and must pass it to the base constructor for DbContext.