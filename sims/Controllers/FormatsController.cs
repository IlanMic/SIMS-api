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
    [Route("api/formats")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private readonly SimsContext _context;

        public FormatsController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/Formats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Format>>> GetFormats()
        {
            return await _context.Formats.ToListAsync();
        }

        // GET: api/Formats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Format>> GetFormat(int id)
        {
            var format = await _context.Formats.FindAsync(id);

            if (format == null)
            {
                return NotFound();
            }

            return format;
        }

        // PUT: api/Formats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormat(int id, Format format)
        {
            if (id != format.Id)
            {
                return BadRequest();
            }

            _context.Entry(format).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormatExists(id))
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

        // POST: api/Formats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Format>> PostFormat(Format format)
        {
            _context.Formats.Add(format);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFormat", new { id = format.Id }, format);
            return CreatedAtAction(nameof(GetFormat), new { id = format.Id }, format);
        }

        // DELETE: api/Formats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormat(int id)
        {
            var format = await _context.Formats.FindAsync(id);
            if (format == null)
            {
                return NotFound();
            }

            _context.Formats.Remove(format);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormatExists(int id)
        {
            return _context.Formats.Any(e => e.Id == id);
        }
    }
}
