using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movieDetails = await _movieRepository.GetById(id);
            var movieModel = new MovieDetailsResponseModel
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                PosterUrl = movieDetails.PosterUrl,
                BackdropUrl = movieDetails.BackdropUrl,
                ImdbUrl = movieDetails.ImdbUrl
            };
            

            foreach (var genre in movieDetails.GenresOfMovie)
            {
                movieModel.Genres.Add(new GenreModel { Id = genre.GenreId, Name = genre.Genre.Name});
            }
            return movieModel;

        }

        public async Task<List<MovieCardResponseModel>> GetTop30GrossingMovies()
        {
            var movies = await _movieRepository.Get30HighestGrossingMovies();

            // map the data from movies (List<Movies> to movieCards (List<MovieCardReposnseModel>)

            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }

            return movieCards;
            
        }
    }
}