using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("fetchallrentals")]

        public IActionResult FetchAllRentals()
        {
            var result = _rentalService.FetchAllRentals();

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("fetchrentalbyid")]

        public IActionResult FetchRentalById(int rentalId)
        {
            var result = _rentalService.FetchRentalById(rentalId);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("addrental")]

        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.AddRental(rental);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("updaterental")]

        public IActionResult UpdateRental(Rental rental)
        {
            var result = _rentalService.UpdateRental(rental);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("deleterental")]

        public IActionResult DeleteRental(Rental rental)
        {
            var result = _rentalService.DeleteRental(rental);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
