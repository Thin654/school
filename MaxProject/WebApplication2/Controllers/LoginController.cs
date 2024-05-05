using Microsoft.AspNetCore.Mvc;
using DBL;
using Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using DBlibrary;

namespace WebApplication2.Controllers
{

    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILogger<LoginController> logger)
        {
            this._logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //[ActionName("GetAllCustomer")]
        //public async Task<List<customer>> Get()
        //{
        //    customerDB customerDB = new customerDB();
        //    return await customerDB.GetAllAsync();
        //}

        //    // POST api/<ToDoListController>
        //[HttpPost]
        //[ActionName("AddNewCustomer")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<customer>> Post1([FromBody] customer customer)
        //{
        //   customerDB customerDB1 = new customerDB();
        //   customer c = await customerDB1.InsertGetObjAsync(customer);
        //   if (c == null) { return StatusCode(StatusCodes.Status500InternalServerError); }
        //   return Ok(c);
        //}

        [HttpGet("Login/{email}/{password}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<customer>> Post2(string email, string password)
        {
                customerDB customerDB = new customerDB();
                customer getCustomer = await customerDB.login(email,password);
                if (getCustomer == null)
                {
                    return BadRequest("User not found");
                }
                if (getCustomer.password == password)
                {
                    return Ok(getCustomer);
                }
                return BadRequest("Invalid password");
        }
    }
}

