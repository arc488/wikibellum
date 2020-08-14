using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wikibellum.Data;

namespace wikibellum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetEvents()
        {
            var entries = _eventRepository.GetAll();
            return Ok(entries);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var entry = _eventRepository.Get(id);
            return Ok(entry);
        }
    }
}
