using HammerSpace.Data;
using HammerSpace.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Services
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }

        //Create a movie and store it to the Database
        public bool CreateMovie(MovieCreate model)
        {
            var entity = new Movie()
            {
                MovieTitle = model.MovieTitle,
                MovieDescription = model.MovieDescription,
                MovieRunTime = model.MovieRunTime,
                Director = model.Director,
                ReleaseYear = model.ReleaseYear,
                MovieGenre = model.MovieGenre,
                MovieRating = model.MovieRating
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovies()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                    .Movies.Where(e => e.MovieTitle == MovieTitle)
                    .Select(
                        e => 
                        new MovieListItem
                        {
                            MovieId = e.Mo
                        })
            }
        }
    }
}
