using NUnit.Framework;
using ReactNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ReactNet.Data;


namespace ReactNet.Controllers
{

    [TestFixture]
    public class MovieDataAccessLayerTests
    {


        [Test]
        public void GetListOfMoviesFromDatabase()
        {
            //connect to database
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                  .UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=reactdb;Pooling=true;")
                  .Options;

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new ApplicationDBContext(options))
            {
                Assert.AreEqual(4, context.Movie.Count());
            }

        }

        [Test]
        public void AddMovieToDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                  .UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=reactdb;Pooling=true;")
                  .Options;

            using (var context = new ApplicationDBContext(options))
            {
                var service = new MovieDataAccessLayer(context);
                var film = new Movie
                {
                    Title = "Another Romantic Comedy",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                };
                service.AddMovie(film);

            }
         
            using (var context = new ApplicationDBContext(options))
            {
                Assert.AreEqual(8, context.Movie.Count());
            }
        }

        [Test]
        public void GetMovieByIdFromDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                  .UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=reactdb;Pooling=true;")
                  .Options;

            using (var context = new ApplicationDBContext(options))
            {
                var service = new MovieDataAccessLayer(context);
                service.GetMovieData(3);

            }

            using (var context = new ApplicationDBContext(options))
            {
                Assert.AreEqual("Ghostbusters 2", context.Movie.Find(3).Title);
            }
        }

        [Test]
        public void DeleteMovieInDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                  .UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=reactdb;Pooling=true;")
                  .Options;

            using (var context = new ApplicationDBContext(options))
            {
                var service = new MovieDataAccessLayer(context);
                //System.ArgumentNullException : Value cannot be null means id does not exist
                service.DeleteMovie(10);

            }

            using (var context = new ApplicationDBContext(options))
            {
                Assert.AreEqual(8, context.Movie.Count());
            }
        }
    }
}
