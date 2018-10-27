using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookAPI_Dapper.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ChinookAPI_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChinookController : ControllerBase
    {
        private readonly Chinook _chinook;

        public ChinookController(IConfiguration config)
        {
            _chinook = new Chinook(config);
        }

        [HttpGet("GetInvoicesBySalesAgentID/{id}")]
        public IActionResult GetInvoicesBySalesAgentID(int id)
        {
            return Ok(_chinook.GetInvoicesBySalesAgentID(id));
        }
    }
}