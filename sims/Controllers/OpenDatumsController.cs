using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sims.Data;
using Sims.Models;

namespace sims.Controllers
{
    [Route("api/datum")]
    [ApiController]
    public class OpenDatumsController : ControllerBase
    {
        private readonly SimsContext _context;

        public OpenDatumsController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/OpenDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpenDatum>>> GetOpenData()
        {
            return await _context.OpenData.ToListAsync();
        }

        // GET: api/OpenDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OpenDatum>> GetOpenDatum(long id)
        {
            var openDatum = await _context.OpenData.FindAsync(id);

            if (openDatum == null)
            {
                return NotFound();
            }

            return openDatum;
        }

        // PUT: api/OpenDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpenDatum(long id, OpenDatum openDatum)
        {
            if (id != openDatum.IdData)
            {
                return BadRequest();
            }

            _context.Entry(openDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpenDatumExists(id))
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

        // POST: api/OpenDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OpenDatum>> PostOpenDatum(OpenDatum openDatum)
        {
            _context.OpenData.Add(openDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOpenDatum", new { id = openDatum.IdData }, openDatum);
        }

        // DELETE: api/OpenDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpenDatum(long id)
        {
            var openDatum = await _context.OpenData.FindAsync(id);
            if (openDatum == null)
            {
                return NotFound();
            }

            _context.OpenData.Remove(openDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpenDatumExists(long id)
        {
            return _context.OpenData.Any(e => e.IdData == id);
        }
    }
}
