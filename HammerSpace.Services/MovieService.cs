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
        //private readonly Guid _userId;

        //public MovieService(Guid userId)
        //{
        //    _userId = userId;
        //}

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

        //Get All movies from database
        public IEnumerable<MovieListItem> GetMovies()
        {
            //Stretch goal: Organize by Title descending

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Movies
                    .Select(
                        e =>
                        new MovieListItem
                        {
                            Id = e.Id,
                            MovieTitle = e.MovieTitle,
                            MovieDescription = e.MovieDescription,
                            Director = e.Director,
                            MovieRunTime = e.MovieRunTime,
                            MovieRating = e.MovieRating,
                            MovieGenre = e.MovieGenre,
                            ReleaseYear = e.ReleaseYear
                        });
                return query.ToArray();
            }
        }

        public MovieDetail GetMovieById(int id)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Movies.Single(e => e.Id == id);
                return
                    new MovieDetail
                    {
                        Id = entity.Id,
                        MovieTitle = entity.MovieTitle,
                        MovieDescription = entity.MovieDescription,
                        MovieRunTime = entity.MovieRunTime,
                        Director = entity.Director,
                        MovieRating = entity.MovieRating,
                        MovieGenre = entity.MovieGenre,
                        ReleaseYear = entity.ReleaseYear
                    };
            }
        }
    }
}