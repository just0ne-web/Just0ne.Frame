using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Just0ne.IService;
using Just0ne.Model;
namespace Just0ne.WebFrontApi.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;


        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            var data =_userService.GetModelByRead("");
            return Ok("webfrontapi");
        }


    }
}