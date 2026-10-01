using Demo1.Data;
using Demo1.Model;
using Demo1.Repo.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IGenaric<Customer> _customerRepo;
        public CustomerController( AppDbContext context , IGenaric<Customer> customerRepo ) {
            _Context = context;
            _customerRepo = customerRepo;
        }




        [HttpPost("add customer")]
        public IActionResult AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null");
            }
            var c = new Customer
            {
                FullName = customer.FullName,
                Email = customer.Email,
                Phone = customer.Phone,
                DriverLicenseNumber = customer.DriverLicenseNumber,
                CustomerProfile = customer.CustomerProfile,


            };
            _customerRepo.Add(c);
            _customerRepo.save();
            return Ok(c);
        }






        [HttpGet("get all customers")]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepo.GetAll().ToList();
            return Ok(customers);
        }



        [HttpPut("update customer {id}")]
        public IActionResult EditCustomer(Customer customer, int id)
        {
            var Customer = _customerRepo.GetById(id);
            if (Customer == null)
            {
                return NotFound("Customer not found");
            }
          Customer.FullName = customer.FullName;
          Customer.Email = customer.Email;
            Customer.Phone = customer.Phone;
            Customer.DriverLicenseNumber = customer.DriverLicenseNumber;
            Customer.CustomerProfile = customer.CustomerProfile;
            _customerRepo.Update(Customer);
            _customerRepo.save();
           
            return Ok(Customer);
        }

        [HttpDelete("delete customer {id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var Customer = _customerRepo.GetById(id);
            if (Customer == null)
            {
                return NotFound("Customer not found");
            }
            _customerRepo.Delete(Customer);
            _customerRepo.save();
            return Ok(Customer);
        }
    }
}
