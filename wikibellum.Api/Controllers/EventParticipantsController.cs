using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wikibellum.Data;
using wikibellum.Entities;

namespace wikibellum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventParticipantsController : ControllerBase
    {
        private readonly WikiContext _context;

        public EventParticipantsController(WikiContext context)
        {
            _context = context;
        }

        // GET: api/EventParticipants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventParticipant>>> GetEventParticipants()
        {
            return await _context.EventParticipants.ToListAsync();
        }

        // GET: api/EventParticipants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventParticipant>> GetEventParticipant(int id)
        {
            var eventParticipant = await _context.EventParticipants.FindAsync(id);

            if (eventParticipant == null)
            {
                return NotFound();
            }

            return eventParticipant;
        }

        // PUT: api/EventParticipants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventParticipant(int id, EventParticipant eventParticipant)
        {
            if (id != eventParticipant.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventParticipant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventParticipantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventParticipants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventParticipant>> PostEventParticipant(EventParticipant eventParticipant)
        {
            _context.EventParticipants.Add(eventParticipant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventParticipant", new { id = eventParticipant.Id }, eventParticipant);
        }

        // DELETE: api/EventParticipants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventParticipant>> DeleteEventParticipant(int id)
        {
            var eventParticipant = await _context.EventParticipants.FindAsync(id);
            if (eventParticipant == null)
            {
                return NotFound();
            }

            _context.EventParticipants.Remove(eventParticipant);
            await _context.SaveChangesAsync();

            return eventParticipant;
        }

        private bool EventParticipantExists(int id)
        {
            return _context.EventParticipants.Any(e => e.Id == id);
        }
    }
}
