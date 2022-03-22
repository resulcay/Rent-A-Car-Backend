using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("fetchallbrands")]

        public IActionResult FetchAllBrands()
        {
            var result = _brandService.FetchAllBrands();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("fetchbrandbyid")]

        public IActionResult FetchBrandById(int brandId)
        {
            var result = _brandService.FetchBrandById(brandId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addbrand")]

        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.AddBrand(brand);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatebrand")]

        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.UpdateBrand(brand);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletebrand")]

        public IActionResult DeleteBrand(Brand brand)
        {
            var result = _brandService.DeleteBrand(brand);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
