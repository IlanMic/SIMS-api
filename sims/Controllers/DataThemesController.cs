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
    [Route("api/themes")]
    [ApiController]
    public class DataThemesController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataThemesController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/DataThemes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataTheme>>> GetDataThemes()
        {
            return await _context.DataThemes.ToListAsync();
        }

        // GET: api/DataThemes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataTheme>> GetDataTheme(int id)
        {
            var dataTheme = await _context.DataThemes.FindAsync(id);

            if (dataTheme == null)
            {
                return NotFound();
            }

            return dataTheme;
        }

        // PUT: api/DataThemes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataTheme(int id, DataTheme dataTheme)
        {
            if (id != dataTheme.IdDataTheme)
            {
                return BadRequest();
            }

            _context.Entry(dataTheme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataThemeExists(id))
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

        // POST: api/DataThemes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataTheme>> PostDataTheme(DataTheme dataTheme)
        {
            _context.DataThemes.Add(dataTheme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataTheme", new { id = dataTheme.IdDataTheme }, dataTheme);
        }

        // DELETE: api/DataThemes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataTheme(int id)
        {
            var dataTheme = await _context.DataThemes.FindAsync(id);
            if (dataTheme == null)
            {
                return NotFound();
            }

            _context.DataThemes.Remove(dataTheme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataThemeExists(int id)
        {
            return _context.DataThemes.Any(e => e.IdDataTheme == id);
        }
    }
}
