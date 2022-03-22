using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;


        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("fetchallcars")]

        public IActionResult FetchAllCars()
        {
            var result = _carService.FetchAllCars();

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("fetchbycarid")]

        public IActionResult FetchCarsByBrandId(int brandId)
        {
            var result = _carService.FetchCarByBrandId(brandId);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("addcar")]

        public IActionResult Add(Car car)
        {
            var result = _carService.AddCar(car);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatecar")]

        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.UpdateCar(car);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletecar")]

        public IActionResult DeleteCar(Car car)
        {
            var result = _carService.DeleteCar(car);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
