using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("fetchallcustomers")]

        public IActionResult FetchAllCustomers()
        {
            var result = _customerService.FetchAllCustomers();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("fetchcustomerbyid")]

        public IActionResult FetchCustomerById(int customerId)
        {
            var result = _customerService.FetchCustomerById(customerId);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addcustomer")]

        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.AddCustomer(customer);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatecustomer")]

        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _customerService.UpdateCustomer(customer);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletecustomer")]

        public IActionResult DeleteCustomer(Customer customer)
        {
            var result = _customerService.DeleteCustomer(customer);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
