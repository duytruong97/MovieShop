using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Movie>> Get30HighestGrossingMovies()
        {
            // return Movies from Database using EF Core and LINQ
            // EF Core does the I/O bound operation
            // EF Core has both async and sync method
            // Dapper, has both async and sync method
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;

        }

        
    }
}
