using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sims.Data;
using sims.DTO;
using Sims.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace sims.Controllers
{
    [Route("api/professions")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        private readonly SimsContext _context;

        public ProfessionsController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/professions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionDTO>>> GetProfessions()
        {
            var professions = _context.Professions.ToList();
            var professionDTOs = new List<ProfessionDTO>();
            foreach (var profession in professions)
            {
                professionDTOs.Add(new ProfessionDTO
                {
                    IdProfession = profession.IdProfession,
                    ProfessionName = profession.ProfessionName
                });
            }
            return professionDTOs;
        }


        //GET: api/professions/2
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessionDTO>> GetProfessionByID(int id)
        {
            ProfessionDTO Profession = await _context.Professions
                .Select(profession => new ProfessionDTO
                {
                    IdProfession = profession.IdProfession,
                    ProfessionName = profession.ProfessionName
                }).FirstOrDefaultAsync(profession => profession.IdProfession == id);
            if (Profession == null)
            {
                return NotFound();
            }
            else
            {
                return Profession;
            }
        }

        //POST: api/professions 
        [HttpPost]
        public async Task<HttpStatusCode> PostProfession(ProfessionDTO ProfessionToPost)
        {
            var entity = new Profession()
            {
                IdProfession = ProfessionToPost.IdProfession,
                ProfessionName = ProfessionToPost.ProfessionName
            };
            _context.Professions.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/professions/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutProfession(ProfessionDTO ProfessionToChange)
        {
            var entity = await _context.Professions.FirstOrDefaultAsync(u => u.IdProfession == ProfessionToChange.IdProfession);
            entity.IdProfession = ProfessionToChange.IdProfession;
            entity.ProfessionName = ProfessionToChange.ProfessionName;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //For HttpDelete look for cascade delete
        //DELETE: api/professions/2
        /*[HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteProfession(ProfessionDTO ProfessionToDelete)
        {
            var entity = new Profession()
            {
                IdProfession = ProfessionToDelete.IdProfession
            };
            _context.Professions.Attach(entity);
            _context.Professions.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}
