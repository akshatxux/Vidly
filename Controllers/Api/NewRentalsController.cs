using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Data;
using Microsoft.AspNetCore.Authorization;

namespace Vidly.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NewRentalsController(ApplicationDbContext injectedContext)
        {
            _context = injectedContext;
        }
        //POST /api/newrentals
        [HttpPost]
        public IActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            if (newRentalDto.MovieIds == null)
                return BadRequest("Invalid movie list.");

            var movies = _context.Movies.Where(
                m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie == null)
                    continue;

                if (movie.NumberAvailable == 0)
                    return BadRequest($"The movie {movie.Name} is not available.");

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
                movie.NumberAvailable--;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
