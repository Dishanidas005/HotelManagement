using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        private readonly hmsContext _Context;
        public RoomsController(hmsContext context)
        {
            _Context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(RoomsController));

        }
        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Rooms> Get()
        {
            return _Context.Rooms.ToList();

        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rooms
        [HttpPost]
        public string Post([FromBody] Rooms value)
        {
            _Context.Rooms.Add(value);
            _ = _Context.SaveChanges();
            return "SUCCESS";

        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
