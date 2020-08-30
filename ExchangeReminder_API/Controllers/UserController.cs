﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeReminder_API.Helpers;
using ExchangeReminder_API.Interface;
using ExchangeReminder_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ExchangeReminder_API.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserOperation userOperation;

        public UserController(IUserOperation userOperation)
        {
            this.userOperation = userOperation;
        }

        [Route("register"), HttpPost]
        public async Task<ActionResult<User>> Register([FromBody] JObject data)
        {
            var registerResponse = await userOperation.RegisterUser(data);

            if (!registerResponse)
                return BadRequest();

            var registeredUser = await userOperation.GetCurrentUser((string)data["email"]);

            if (registeredUser == null)
                return BadRequest();

            return registeredUser;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
