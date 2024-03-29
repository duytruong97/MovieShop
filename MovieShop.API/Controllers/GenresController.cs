﻿using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        } 

        //api/genres/

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _genreService.GetAllGenres();
            // return JSON data
            // Serialize C# to JSON
            // NewtonSoft.JSON (ASP.NET CORE after 3 have something caleld System.Text.json)
            // API .. always return HTTP status codes along with data
            if (!genres.Any())
            {
                // 404
                return NotFound();
            } 

            //200
            return Ok(genres);

            
        }

    }
}
