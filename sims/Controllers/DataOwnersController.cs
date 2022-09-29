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
    [Route("api/dataowners")]
    [ApiController]
    public class DataOwnersController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataOwnersController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/DataOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataOwner>>> GetDataOwners()
        {
            return await _context.DataOwners.ToListAsync();
        }

        // GET: api/DataOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataOwner>> GetDataOwner(long id)
        {
            var dataOwner = await _context.DataOwners.FindAsync(id);

            if (dataOwner == null)
            {
                return NotFound();
            }

            return dataOwner;
        }

        // PUT: api/DataOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataOwner(long id, DataOwner dataOwner)
        {
            if (id != dataOwner.IdDataOwner)
            {
                return BadRequest();
            }

            _context.Entry(dataOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataOwnerExists(id))
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

        // POST: api/DataOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataOwner>> PostDataOwner(DataOwner dataOwner)
        {
            _context.DataOwners.Add(dataOwner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataOwner", new { id = dataOwner.IdDataOwner }, dataOwner);
        }

        // DELETE: api/DataOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataOwner(long id)
        {
            var dataOwner = await _context.DataOwners.FindAsync(id);
            if (dataOwner == null)
            {
                return NotFound();
            }

            _context.DataOwners.Remove(dataOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataOwnerExists(long id)
        {
            return _context.DataOwners.Any(e => e.IdDataOwner == id);
        }
    }
}
