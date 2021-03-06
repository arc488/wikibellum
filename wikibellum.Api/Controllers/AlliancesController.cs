﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wikibellum.Data;
using wikibellum.Entities.Models;

namespace wikibellum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlliancesController : ControllerBase
    {
        private readonly WikiContext _context;

        public AlliancesController(WikiContext context)
        {
            _context = context;
        }

        // GET: api/Alliances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alliance>>> GetAlliances()
        {

            return await _context.Alliances.ToListAsync();
        }

        // GET: api/Alliances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alliance>> GetAlliance(int id)
        {
            var alliance = await _context.Alliances.FindAsync(id);

            if (alliance == null)
            {
                return NotFound();
            }

            return alliance;
        }

        // PUT: api/Alliances/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlliance(int id, Alliance alliance)
        {
            if (id != alliance.AllianceId)
            {
                return BadRequest();
            }

            _context.Entry(alliance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllianceExists(id))
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

        // POST: api/Alliances
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Alliance>> PostAlliance(Alliance alliance)
        {
            _context.Alliances.Add(alliance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AllianceExists(alliance.AllianceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlliance", new { id = alliance.AllianceId }, alliance);
        }

        // DELETE: api/Alliances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alliance>> DeleteAlliance(int id)
        {
            var alliance = await _context.Alliances.FindAsync(id);
            if (alliance == null)
            {
                return NotFound();
            }

            _context.Alliances.Remove(alliance);
            await _context.SaveChangesAsync();

            return alliance;
        }

        private bool AllianceExists(int id)
        {
            return _context.Alliances.Any(e => e.AllianceId == id);
        }
    }
}
