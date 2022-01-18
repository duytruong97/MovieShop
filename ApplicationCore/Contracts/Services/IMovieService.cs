using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // create these service methods absed on your UI/business requirements
        // Controllers will access these methods
        Task<List<MovieCardResponseModel>> GetTop30GrossingMovies();
    }
}