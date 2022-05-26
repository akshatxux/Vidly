using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext injectedContext)
        {
            _context = injectedContext;
        }
        public IActionResult Random()
        {
            Movie? movie = new Movie() { Id = 1, Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer() { Id = 1, Name = "Customer 1"},
                new Customer() { Id = 2, Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            }; 
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;
            return View(viewModel);
            //return Content("Hello World");
            //return NotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public IActionResult New()
        {
            var genreList = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genreList
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;  //update date added field for new movies
            }

            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
            //return Content("id=" + id);
        }

        //movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            
            return View("ReadOnlyList");

            //if (!pageIndex.HasValue)
            //    pageIndex = 1;

            //if (String.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";

            //return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

            //List<Movie>? movies = _context.Movies.Include(m => m.Genre).ToList();
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }
        [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
