using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForPracticeItems.MovieRepo
{
    public static class MovieFactory
    {
        public static IMovieRepository CreateMovieRepository()
        {
            switch (ConfigurationManager.AppSettings["mode"].ToLower())
            {
                case "prod":
                    return new MovieRepository();
                case "test":
                    return new MockMovieRepository();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
