using Microsoft.AspNetCore.Mvc;
using DBL;
using Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDBController : Controller
    {

        private readonly ILogger<BaseDBController> _logger;
        public BaseDBController(ILogger<BaseDBController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("GetSelectAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetHelloWorld() 
        {
            return Ok("helloworld");
        }
    }
}
