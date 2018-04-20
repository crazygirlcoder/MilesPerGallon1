using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "C:/Users/sharmishta/Downloads/NewMovies.csv";
            var csvRows = System.IO.File.ReadAllLines(path, Encoding.Default).ToArray();
            Dictionary<int, List<MovieDetails>> dictionary = new Dictionary<int, List<MovieDetails>>();

            foreach (var row in csvRows.Skip(1))
            {
                MovieDetails movie = new MovieDetails();
                var columns = row.Split(',');
                movie.MovieName = columns[0];
                movie.Genere = columns[1];
                movie.YearReleased = Convert.ToInt32(columns[2]);

                if (!dictionary.Keys.Contains(movie.YearReleased))
                    dictionary.Add(movie.YearReleased, new List<MovieDetails>());


                dictionary[movie.YearReleased].Add(movie);
                          
            }

            var rangeMPGs = GetMovie(2016, 2018);
            List<MovieDetails> GetMovie( int movieYearBegin, int movieYearEnd)
            {
                var movies = new List<MovieDetails>();
                for(var i = movieYearBegin; i<= movieYearEnd; i++)
                {
                    if (dictionary.Keys.Contains(i))
                    {
                        var bob = dictionary[i];
                        movies.AddRange(bob);
                    }

                }

                return movies;
            }
        }

    }
}
