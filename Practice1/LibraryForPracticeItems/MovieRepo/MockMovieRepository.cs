using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForPracticeItems.MovieRepo
{
    public class MockMovieRepository : IMovieRepository
    {
        private static List<Movie> _movies = new List<Movie>();

        public MockMovieRepository()
        {
            if (!_movies.Any())
            {
                _movies.AddRange(new List<Movie>()
                {
                    new Movie
                    {
                        MovieId = 1,
                        Title = "Ghostbusters",
                        Rating = "PG",
                        ReleaseDate = DateTime.Parse("6/8/1984")
                    },
                    new Movie
                    {
                        MovieId = 2,
                        Title = "Beatlejuic",
                        Rating = "PG",
                        ReleaseDate = DateTime.Parse("3/30/1988")
                    },
                    new Movie
                    {
                        MovieId = 3,
                        Title = "Star Wars",
                        Rating = "PG",
                        ReleaseDate = DateTime.Parse("5/25/1977")
                    }
                });
            };
        }
    }
}
