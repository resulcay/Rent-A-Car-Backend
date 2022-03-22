using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("fetchallusers")]

        public IActionResult FetchAllUsers()
        {
            var result = _userService.FetchAllUsers();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("fetchuserbyid")]

        public IActionResult FetchUserById(int userId)
        {
            var result = _userService.FetchUserById(userId);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("adduser")]

        public IActionResult AddUser(User user)
        {
            var result = _userService.AddUser(user);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("updateuser")]

        public IActionResult UpdateUser(User user)
        {
            var result = _userService.UpdateUser(user);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("deleteuser")]

        public IActionResult DeleteUser(User user)
        {
            var result = _userService.DeleteUser(user);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
    }
}
