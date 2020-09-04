using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase

    {
        readonly log4net.ILog _log4net;
        private readonly hmsContext _Context;
        public UsersController(hmsContext context)
        {
            _Context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(UsersController));

        }
        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _Context.Users.ToList();

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public string Post([FromBody] Users value)

        {
             _Context.Users.Add(value);
            _Context.SaveChanges();
            return "SUCCESS";

        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUsers(string id, [FromBody]Users users)
        {
            // _context.Entry(users).State = EntityState.Modified;
            Users u = _Context.Users.Find(id);
            u.FirstName = users.FirstName;
            u.LastName = users.LastName;
            u.Password = users.Password;
            _Context.Users.Update(u);

            try
            {
                _Context.SaveChanges();
                return Ok("Updation Sucessfull");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool UsersExists(string id)
        {
            throw new NotImplementedException();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
