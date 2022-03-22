using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("fetchallcarimages")]
        public IActionResult FetchAllCars()
        {
            var result = _carImageService.FetchAllCarImages();

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("fetchcarimagebyid")]
        public IActionResult FetchCarImageById(int carImageId)
        {
            var result = _carImageService.FetchCarImageById(carImageId);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("addcarimage")]
        public IActionResult AddCarImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.AddCarImage(carImage, file);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatecarimage")]
        public IActionResult UpdateCarImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.UpdateCarImage(carImage, file);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("deletecarimage")]
        public IActionResult DeleteCarImage(CarImage carImage)
        {
            var result = _carImageService.DeleteCarImage(carImage);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
