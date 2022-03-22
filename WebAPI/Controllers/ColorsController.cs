using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("fetchallcolors")]

        public IActionResult FetchAllColors()
        {
            var result = _colorService.FetchAll();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("fetchcolorbyid")]

        public IActionResult FetchColorById(int colorId)
        {
            var result = _colorService.FetchColorById(colorId);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("addcolor")]

        public IActionResult AddColor(Color color)
        {
            var result = _colorService.AddColor(color);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatecolor")]

        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.AddColor(color);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletecolor")]

        public IActionResult DeleteColor(Color color)
        {
            var result = _colorService.DeleteColor(color);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
