using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeReminder_API.Helpers;
using ExchangeReminder_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ExchangeReminder_API.Controllers
{
    [Route("api/exchange")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeOperation exchangeOperation;

        public ExchangeRateController(IExchangeOperation exchangeOperation)
        {
            this.exchangeOperation = exchangeOperation;
        }

        [Route("create_exchange"), HttpPost]
        public async Task<ActionResult<User>> Register([FromBody] JObject data)
        {
            var exchangeResponse = await exchangeOperation.CreateExchangeRecord(data);

            if (!exchangeResponse)
                return BadRequest();


            return new User();
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
