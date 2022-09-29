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
    [Route("api/datausages")]
    [ApiController]
    public class DataUsagesController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataUsagesController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/DataUsages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataUsage>>> GetDataUsages()
        {
            return await _context.DataUsages.ToListAsync();
        }

        // GET: api/DataUsages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataUsage>> GetDataUsage(long id)
        {
            var dataUsage = await _context.DataUsages.FindAsync(id);

            if (dataUsage == null)
            {
                return NotFound();
            }

            return dataUsage;
        }

        // PUT: api/DataUsages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataUsage(long id, DataUsage dataUsage)
        {
            if (id != dataUsage.IdDataUsage)
            {
                return BadRequest();
            }

            _context.Entry(dataUsage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataUsageExists(id))
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

        // POST: api/DataUsages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataUsage>> PostDataUsage(DataUsage dataUsage)
        {
            _context.DataUsages.Add(dataUsage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataUsage", new { id = dataUsage.IdDataUsage }, dataUsage);
        }

        // DELETE: api/DataUsages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataUsage(long id)
        {
            var dataUsage = await _context.DataUsages.FindAsync(id);
            if (dataUsage == null)
            {
                return NotFound();
            }

            _context.DataUsages.Remove(dataUsage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataUsageExists(long id)
        {
            return _context.DataUsages.Any(e => e.IdDataUsage == id);
        }
    }
}
