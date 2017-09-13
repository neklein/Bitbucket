using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForPracticeItems.MovieRepo
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();

        Movie SaveNewMovie(Movie movieToSave);


        Movie UpdateMovie(Movie movieToUpdate);

        void DeleteMovie(int movieToDelete);
        

    }
}
