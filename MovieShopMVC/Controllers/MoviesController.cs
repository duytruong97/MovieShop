using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        // Details 
        // Topratedmovies
        // Topgrossingmovies
        // 
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        public async Task<IActionResult> Details (int id)
        {
            var MovieDetails = await _movieService.GetMovieDetails (id);
            return View();
        }
    }
}
