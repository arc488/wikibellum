using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wikibellum.Data;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly WikiContext _context;

        public AssetsController(WikiContext context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            return await _context.Assets.ToListAsync();
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(int id)
        {
            var asset = await _context.Assets.FindAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            return asset;
        }

        // PUT: api/Assets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(int id, Asset asset)
        {
            if (id != asset.AssetId)
            {
                return BadRequest();
            }

            _context.Entry(asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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

        // POST: api/Assets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(Asset asset)
        {
            asset.Classification = _context.Classifications.Find(asset.ClassificationId);
            if (asset.AssetType == AssetType.Loss)
            {
                asset.ConditionId = Int32.Parse(asset.ConditionIdString);
                asset.Condition = _context.Conditions.Find(asset.ConditionId);
            }
            _context.Assets.Add(asset);
           
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsset", new { id = asset.AssetId }, asset);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asset>> DeleteAsset(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();

            return asset;
        }

        private bool AssetExists(int id)
        {
            return _context.Assets.Any(e => e.AssetId == id);
        }
    }
}
