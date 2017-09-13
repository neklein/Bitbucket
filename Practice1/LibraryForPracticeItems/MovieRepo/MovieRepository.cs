using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForPracticeItems.MovieRepo
{
    public class MovieRepository : IMovieRepository
    {
        var repo = MovieFactory.CreateMovieRepository();

        public void DeleteMovie(int movieToDelete)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMovies()
        {
            throw new NotImplementedException();
        }

        public Movie SaveNewMovie(Movie movieToSave)
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovie(Movie movieToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
