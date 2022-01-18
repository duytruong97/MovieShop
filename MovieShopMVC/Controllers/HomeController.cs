using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;






        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // call Movie Service to get topgrossingmovies
            // 3 ways we can pass the data from COntroller/Action methods to the Views
            // 1. *** Pass the Strongly Typed Models ***
            // 2. ViewBag => dynamic
            // 3. ViewData => object key/value

            var movies = await _movieService.GetTop30GrossingMovies();
            ViewBag.TotalMovies = movies.Count;
            return View(movies);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        // http://localhost:53535/Home/TopMovies
        [HttpGet]
        public IActionResult TopMovies()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}