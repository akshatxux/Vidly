using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            //if (viewModel.Customer.Id == 0)
            //    _context.Customers.Add(viewModel.Customer);
            //else

            _context.Customers.Update(customer); //will add if primary key not already present
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        public IActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();

            return View(customers);
        }
        [Route("Customers/Details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == id);
            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "Ak"},
        //        new Customer { Id = 2, Name = "Qk"}
        //    };
        //}
    }
}
