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
    [Route("api/professionfields")]
    [ApiController]
    public class ProfessionFieldsController : ControllerBase
    {
        private readonly SimsContext _context;

        public ProfessionFieldsController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/ProfessionFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionField>>> GetProfessionFields()
        {
            return await _context.ProfessionFields.ToListAsync();
        }

        // GET: api/ProfessionFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessionField>> GetProfessionField(int id)
        {
            var professionField = await _context.ProfessionFields.FindAsync(id);

            if (professionField == null)
            {
                return NotFound();
            }

            return professionField;
        }

        // PUT: api/ProfessionFields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessionField(int id, ProfessionField professionField)
        {
            if (id != professionField.IdProfessionField)
            {
                return BadRequest();
            }

            _context.Entry(professionField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionFieldExists(id))
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

        // POST: api/ProfessionFields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfessionField>> PostProfessionField(ProfessionField professionField)
        {
            _context.ProfessionFields.Add(professionField);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessionField", new { id = professionField.IdProfessionField }, professionField);
        }

        // DELETE: api/ProfessionFields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessionField(int id)
        {
            var professionField = await _context.ProfessionFields.FindAsync(id);
            if (professionField == null)
            {
                return NotFound();
            }

            _context.ProfessionFields.Remove(professionField);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessionFieldExists(int id)
        {
            return _context.ProfessionFields.Any(e => e.IdProfessionField == id);
        }
    }
}
