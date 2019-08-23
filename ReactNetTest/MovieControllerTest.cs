using NUnit.Framework;
using ReactNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ReactNet.Data;


namespace ReactNet.Controllers
{
    [TestFixture]
    public class MovieControllerTests
    {
        [Test]
        public void Create_writes_to_database()
        {
            //connect to database
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                  .UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=reactdb;Pooling=true;")
                  .Options;

            // Run the test against one instance of the context
            using (var context = new ApplicationDBContext(options))
            {
                var service = new MovieController(context);
                var film = new Movie
                {
                    Title = "Another Romantic Comedy",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                };
                service.Create(film);
                //context.SaveChanges();
               
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new ApplicationDBContext(options))
            {
                Assert.AreEqual(5, context.Movie.Count());
                //Assert.AreEqual("film input", context.Movie.Single().Title.ToList());
            }
        }

        [Test]
        public void Find_searches_title()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                  .UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=reactdb;Pooling=true;")
                  .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApplicationDBContext(options))
            {
                context.Movie.Add(new Movie
                {
                    Title = "Another Romantic Comedy",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 9.99M
                });
                context.Movie.Add(new Movie
                {
                    Title = "Another Romantic Comedy",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 72.99M
                });
                context.Movie.Add(new Movie
                {
                    Title = "Another Romantic Comedy",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 37.99M
                });
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApplicationDBContext(options))
            {
                var service = new MovieController(context);
                var result = service.Find("Comedy");
                Assert.AreEqual(4, context.Movie.Count());
            }
        }
    }
}
