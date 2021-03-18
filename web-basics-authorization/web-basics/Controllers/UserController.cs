using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_basics.business.Domains;
using web_basics.business.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        business.Domains.Account domain;
        public UserController(IConfiguration configuration)
        {
            this.domain = new business.Domains.Account(configuration);
        }
        // GET: api/<UserController>
        [HttpGet]
        [Authorize(Roles = "Admin,Moder")]
        public IActionResult GetUsers()
        {
            return Ok(this.domain.Get());
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(business.ViewModels.Account account)
        {
            this.domain.Create(account);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.domain.Delete(id);
        }
    }
}
