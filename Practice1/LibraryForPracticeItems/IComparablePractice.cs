using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForPracticeItems
{
    public class IComparablePractice : IComparable<MovieRating>
    {
        public string Title { get; set; }
        public int Rating { get; set; }

        public int CompareTo(MovieRating other)
        {
            if (other == null) return 1;

            return this.Rating.CompareTo(other.Rating);
        }

        List<MovieRating> movies = new List<MovieRating>();
        movies.Add(new MovieRating { Title = "Her", Rating = 8});
movies.Add(new MovieRating { Title = "Fletch", Rating = 5 });
movies.Add(new MovieRating { Title = "Superbabies: Baby Geniuses 2", Rating = 9 });
movies.Add(new MovieRating { Title = "Howl's Moving Castle", Rating = 10 });
movies.Sort();
    }
}
