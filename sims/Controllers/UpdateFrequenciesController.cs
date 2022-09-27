using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sims.Models;

namespace sims.Controllers
{
    [Route("api/updatefrequencies")]
    [ApiController]
    public class UpdateFrequenciesController : ControllerBase
    {
        private readonly SimsContext _context;

        public UpdateFrequenciesController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/UpdateFrequencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateFrequency>>> GetUpdateFrequencies()
        {
            return await _context.UpdateFrequencies.ToListAsync();
        }

        // GET: api/UpdateFrequencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UpdateFrequency>> GetUpdateFrequency(int id)
        {
            var updateFrequency = await _context.UpdateFrequencies.FindAsync(id);

            if (updateFrequency == null)
            {
                return NotFound();
            }

            return updateFrequency;
        }

        // PUT: api/UpdateFrequencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdateFrequency(int id, UpdateFrequency updateFrequency)
        {
            if (id != updateFrequency.Id)
            {
                return BadRequest();
            }

            _context.Entry(updateFrequency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpdateFrequencyExists(id))
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

        // POST: api/UpdateFrequencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UpdateFrequency>> PostUpdateFrequency(UpdateFrequency updateFrequency)
        {
            _context.UpdateFrequencies.Add(updateFrequency);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUpdateFrequency", new { id = updateFrequency.Id }, updateFrequency);
            return CreatedAtAction(nameof(GetUpdateFrequency), new { id = updateFrequency.Id }, updateFrequency);
        }

        // DELETE: api/UpdateFrequencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUpdateFrequency(int id)
        {
            var updateFrequency = await _context.UpdateFrequencies.FindAsync(id);
            if (updateFrequency == null)
            {
                return NotFound();
            }

            _context.UpdateFrequencies.Remove(updateFrequency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UpdateFrequencyExists(int id)
        {
            return _context.UpdateFrequencies.Any(e => e.Id == id);
        }
    }
}
