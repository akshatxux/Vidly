using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Data;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CustomersController(ApplicationDbContext injectedContext, IMapper injectedMapper)
        {
            _context = injectedContext;
            _mapper = injectedMapper;
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(x => _mapper.Map<CustomerDto>(x));
        }

        // GET /api/customers/1
        [HttpGet("{id}")]
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                throw new ApplicationException(HttpContext.Response.StatusCode.ToString());

            return _mapper.Map<CustomerDto>(customer);
        }

        // POST /api/customer
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ApplicationException(HttpContext.Response.StatusCode.ToString());
            }

            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        [HttpPut("{id}")]
        // PUT /api/customers/1
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new ApplicationException(HttpContext.Response.StatusCode.ToString());

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new ApplicationException(HttpContext.Response.StatusCode.ToString());

            _mapper.Map(customerDto, customerInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.isSubscribedToNewsletter = customerDto.isSubscribedToNewsletter;
            //customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            //_context.Customers.Update(customer);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        // DELETE /api/customers/1
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new ApplicationException(HttpContext.Response.StatusCode.ToString());

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
