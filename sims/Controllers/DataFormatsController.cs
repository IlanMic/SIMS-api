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
    [Route("api/formats")]
    [ApiController]
    public class DataFormatsController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataFormatsController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/DataFormats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataFormat>>> GetDataFormats()
        {
            return await _context.DataFormats.ToListAsync();
        }

        // GET: api/DataFormats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataFormat>> GetDataFormat(int id)
        {
            var dataFormat = await _context.DataFormats.FindAsync(id);

            if (dataFormat == null)
            {
                return NotFound();
            }

            return dataFormat;
        }

        // PUT: api/DataFormats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataFormat(int id, DataFormat dataFormat)
        {
            if (id != dataFormat.IdDataFormat)
            {
                return BadRequest();
            }

            _context.Entry(dataFormat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataFormatExists(id))
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

        // POST: api/DataFormats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataFormat>> PostDataFormat(DataFormat dataFormat)
        {
            _context.DataFormats.Add(dataFormat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataFormat", new { id = dataFormat.IdDataFormat }, dataFormat);
        }

        // DELETE: api/DataFormats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataFormat(int id)
        {
            var dataFormat = await _context.DataFormats.FindAsync(id);
            if (dataFormat == null)
            {
                return NotFound();
            }

            _context.DataFormats.Remove(dataFormat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataFormatExists(int id)
        {
            return _context.DataFormats.Any(e => e.IdDataFormat == id);
        }
    }
}
