using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //Show movies purchased
        //Show favorite movies
        //Add reviews
        //Edit movie reviews
        //Purchase a movie
        //Favorite a movie
        //Unfavorite a movie


        //ASP.NET has Filters: Authorization Filter 

        [HttpGet]
        public async Task<IActionResult> Purchases()
        {

            //HttpContext => encapsulate all the Httpe request information 
            

        //    var isLogedin = HttpContext.User.Identity.IsAuthenticated;
                //call user service  with logged in user id and get the movies user purchased from Purchase table
                var userId = Convert.ToInt32(HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Favorite()
        {
            var userId = Convert.ToInt32(HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return View();
        }
    }

    
}
