using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sims.Data;
using sims.DTO;
using Sims.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/professionfields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionFieldDTO>>> GetProfessionFields()
        {
            var professionfields = _context.ProfessionFields.ToList();
            var professionfieldDTOs = new List<ProfessionFieldDTO>();
            foreach (var professionfield in professionfields)
            {
                professionfieldDTOs.Add(new ProfessionFieldDTO
                {
                    IdProfessionField = professionfield.IdProfessionField,
                    ProfessionFieldName = professionfield.ProfessionFieldName
                });
            }
            return professionfieldDTOs;
        }


        //GET: api/professionfields/2
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessionFieldDTO>> GetProfessionFieldByID(int id)
        {
            ProfessionFieldDTO ProfessionField = await _context.ProfessionFields
                .Select(professionField => new ProfessionFieldDTO
                {
                    IdProfessionField = professionField.IdProfessionField,
                    ProfessionFieldName = professionField.ProfessionFieldName
                }).FirstOrDefaultAsync(professionField => professionField.IdProfessionField == id);
            if (ProfessionField == null)
            {
                return NotFound();
            }
            else
            {
                return ProfessionField;
            }
        }

        //POST: api/professionfields 
        [HttpPost]
        public async Task<HttpStatusCode> PostProfessionField(ProfessionFieldDTO ProfessionFieldToPost)
        {
            var entity = new ProfessionField()
            {
                IdProfessionField = ProfessionFieldToPost.IdProfessionField,
                ProfessionFieldName = ProfessionFieldToPost.ProfessionFieldName
            };
            _context.ProfessionFields.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/professionfields/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutProfessionField(ProfessionFieldDTO ProfessionFieldToChange)
        {
            var entity = await _context.ProfessionFields.FirstOrDefaultAsync(u => u.IdProfessionField == ProfessionFieldToChange.IdProfessionField);
            entity.IdProfessionField = ProfessionFieldToChange.IdProfessionField;
            entity.IdProfessionField = ProfessionFieldToChange.IdProfessionField;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //For HttpDelete look for cascade delete
        //DELETE: api/professionfields/2
        /*[HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteProfessionField(ProfessionFieldDTO ProfessionFieldToDelete)
        {
            var entity = new ProfessionField()
            {
                IdProfessionField = ProfessionFieldToDelete.IdProfessionField
            };
            _context.ProfessionFields.Attach(entity);
            _context.ProfessionFields.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}
