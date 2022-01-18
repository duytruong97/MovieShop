using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        // Details 
        // Topratedmovies
        // Topgrossingmovies
        // 

        public async Task<IActionResult> Details (int id)
        {
            return View();
        }
    }
}
