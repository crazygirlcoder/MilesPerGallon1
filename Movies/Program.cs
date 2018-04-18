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
            var path = "C:/Users/sharmishta/Downloads/movies.csv";
            var csvRows = System.IO.File.ReadAllLines(path, Encoding.Default).ToArray();
            MovieDetails movie = new MovieDetails();

            Dictionary<DateTime, List<MovieDetails>> dictionary = new Dictionary<DateTime, List<MovieDetails>>();

            foreach (var row in csvRows.Skip(1))
            {
                var columns = row.Split(',');
                movie.MovieName = columns[0];
                movie.Genere = columns[1];
                movie.YearReleased = Convert.ToDateTime(columns[2]);

                if (!dictionary.Keys.Contains(movie.YearReleased))
                    dictionary.Add(movie.YearReleased, new List<MovieDetails>());

                dictionary[movie.YearReleased].Add(movie);
               
            }

            var rangeMPGs = GetMovie(Convert.ToDateTime("04/18/2018 12:00:00 AM"), Convert.ToDateTime("04/18/2017 12:00:00 AM"));
            List<MovieDetails> GetMovie( DateTime movieYearBegin, DateTime movieYearEnd)
            {
                List<MovieDetails> moviesInGivenYear1 = new List<MovieDetails>();
                List<MovieDetails> moviesInGivenYear2 = new List<MovieDetails>();

                if (dictionary.Keys.Contains(movieYearBegin ))
                {
                   moviesInGivenYear1 = dictionary[movieYearBegin];
                }

                if (dictionary.Keys.Contains(movieYearEnd))
                {
                    moviesInGivenYear2 = dictionary[movieYearEnd];
                }
               
                var movies = moviesInGivenYear1.Concat(moviesInGivenYear2).ToList();


                return movies;
            }
        }

    }
}
