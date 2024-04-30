using Microsoft.AspNetCore.Mvc;
using DBL;
using Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using DBlibrary;

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
  //      [ActionName("PostTrasaction")]
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

        [HttpPost("InsertTrade")]
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
        [HttpGet("GetAll/{id}")]
        // [ActionName("GetByUid")] // use only if U have the same function header
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<transaction>>> GetAsync(int id)
        {
            // logger exampe - not required but recommended
            //this._logger.LogInformation("Get BaseUser by uid");
            if (id <= 0)
            {
                return BadRequest();
            }
            transactionDB tdb = new transactionDB();
            List<transaction> l = await tdb.SelectByCustomer(id);
            if (l == null)
            {
                // logger exampe - not required but recommended
                return NotFound();
            }
            return Ok(l);
        }
        [HttpGet("GetAllTrades/{id}")]
        // [ActionName("GetByUid")] // use only if U have the same function header
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<trade>>> GetTradesAsync(int id)
        {
            // logger exampe - not required but recommended
            //this._logger.LogInformation("Get BaseUser by uid");
            if (id <= 0)
            {
                return BadRequest();
            }
            tradeDB tdb = new tradeDB();
            List<trade> l = await tdb.SelectByCustomer(id);
            if (l == null)
            {
                // logger exampe - not required but recommended
                return NotFound();
            }
            return Ok(l);
        }
        [HttpGet("GetSum/{id}/{coincode}/{sl}")]
        // [ActionName("GetByUid")] // use only if U have the same function header
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<double>> GetAsync(int id, int coincode, double sl)
        {
            // logger exampe - not required but recommended
            //this._logger.LogInformation("Get BaseUser by uid");
            if (id <= 0 && coincode <= 0)
            {
                return BadRequest();
            }
            //DoubleDB d = new DoubleDB();
            //List<double> list_trades = await d.GetSUMByCoinAndCustomer(id, coincode);
            tradeDB tdb = new tradeDB();
            object sum = await tdb.GetSum(id,coincode, sl);
            if (sum is System.DBNull)
            {
                // logger exampe - not required but recommended
                return Ok(0);
            }
            return Ok(sum);
        }
    }
}
