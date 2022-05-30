using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Vidly.Data;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext injectedContext, IMapper injectedmapper)
        {
            _context = injectedContext;
            _mapper = injectedmapper;
        }

        // GET /api/movies
        [HttpGet]
        public IActionResult GetMovies()
        {
            var moviesDto = _context.Movies.
                Include(m => m.Genre).
                ToList().
                Select(movie => _mapper.Map<Movie, MovieDto>(movie));
            return Ok(moviesDto);
        }

        // GET /api/movies/1
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.
                Include(_m => _m.Genre).
                SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return NotFound();

            var movieDto = _mapper.Map<Movie, MovieDto>(movie);

            return Ok(movieDto);
        }

        // POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            movie.NumberAvailable = movie.NumberInStock;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.GetDisplayUrl()), movieDto);
        }

        // PUT /api/movies/1
        [HttpPut("{id}")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(movie => movie.Id == id);

            if (movieInDb == null)
                return NotFound();

            if (movieInDb.NumberInStock != movieDto.NumberInStock)
                movieInDb.NumberAvailable = movieInDb.NumberInStock - _context.Rentals.Count(r => (r.Movie.Id == movieInDb.Id) && (r.DateReturned == null));

            _mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(movie =>movie.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
