using Microsoft.AspNetCore.Mvc;
using DBL;
using Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace WebApplication2.Controllers
{
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
        [HttpPost("InsertTrans")]
        [ActionName("PostCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Models.transaction>> PostTransAsync([FromBody] Models.transaction t)
        {
            transactionDB td = new transactionDB();
            transaction c = await td.InsertGetObjAsync(t);
            if (c == null)
            { return StatusCode(StatusCodes.Status500InternalServerError); }
            return Ok(c);
        }

        [HttpGet("InsertTrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<trade>> PostTradeAsync([FromBody] trade t)
        {
            tradeDB td = new tradeDB();
            trade c = await td.InsertGetObjAsync(t);
            if (c == null)
            { return StatusCode(StatusCodes.Status500InternalServerError); }
            return Ok(c);
        }
    }
}
