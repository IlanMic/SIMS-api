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
    [Route("api/languages")]
    [ApiController]
    public class DataLanguagesController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataLanguagesController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/DataLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataLanguage>>> GetDataLanguages()
        {
            return await _context.DataLanguages.ToListAsync();
        }

        // GET: api/DataLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataLanguage>> GetDataLanguage(int id)
        {
            var dataLanguage = await _context.DataLanguages.FindAsync(id);

            if (dataLanguage == null)
            {
                return NotFound();
            }

            return dataLanguage;
        }

        // PUT: api/DataLanguages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataLanguage(int id, DataLanguage dataLanguage)
        {
            if (id != dataLanguage.IdDataLanguage)
            {
                return BadRequest();
            }

            _context.Entry(dataLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataLanguageExists(id))
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

        // POST: api/DataLanguages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataLanguage>> PostDataLanguage(DataLanguage dataLanguage)
        {
            _context.DataLanguages.Add(dataLanguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataLanguage", new { id = dataLanguage.IdDataLanguage }, dataLanguage);
        }

        // DELETE: api/DataLanguages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataLanguage(int id)
        {
            var dataLanguage = await _context.DataLanguages.FindAsync(id);
            if (dataLanguage == null)
            {
                return NotFound();
            }

            _context.DataLanguages.Remove(dataLanguage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataLanguageExists(int id)
        {
            return _context.DataLanguages.Any(e => e.IdDataLanguage == id);
        }
    }
}
