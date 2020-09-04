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
    public class BookingController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        private readonly hmsContext _Context;
        public BookingController(hmsContext context)
        {
            _Context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(BookingController));

        }
        // GET: api/Booking
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return _Context.Bookings.ToList();
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        [HttpPost]
        public string Post([FromBody] Booking value)
        {

            _Context.Bookings.Add(value);
            _Context.SaveChanges();
            return "SUCCESS";

        }

        // PUT: api/Booking/5
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
