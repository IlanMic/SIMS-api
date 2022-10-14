using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sims.Data;
using sims.DTO;
using Sims.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace sims.Controllers
{
    [Route("api/updatefrequencies")]
    [ApiController]
    public class UpdateFrequenciesController : ControllerBase
    {
        private readonly SimsContext _context;

        public UpdateFrequenciesController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/updatefrequencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateFrequencyDTO>>> GetUpdateFrequencies()
        {
            var updateFrequencies = _context.UpdateFrequencies.ToList();
            var updateFrequencyDTOs = new List<UpdateFrequencyDTO>();
            foreach (var updateFrequency in updateFrequencies)
            {
                updateFrequencyDTOs.Add(new UpdateFrequencyDTO
                {
                    IdUpdateFrequency = updateFrequency.IdUpdateFrequency,
                    UpdateFrequencyName = updateFrequency.UpdateFrequencyName
                });
            }
            return updateFrequencyDTOs;
        }


        //GET: api/updatefrequencies/2
        [HttpGet("{id}")]
        public async Task<ActionResult<UpdateFrequencyDTO>> GetupdateFrequencyById(int id)
        {
            UpdateFrequencyDTO UpdateFrequency = await _context.UpdateFrequencies
                .Select(updateFrequency => new UpdateFrequencyDTO
                {
                    IdUpdateFrequency = updateFrequency.IdUpdateFrequency,
                    UpdateFrequencyName = updateFrequency.UpdateFrequencyName
                }).FirstOrDefaultAsync(updateFrequency => updateFrequency.IdUpdateFrequency == id);
            if (UpdateFrequency == null)
            {
                return NotFound();
            }
            else
            {
                return UpdateFrequency;
            }
        }

        //POST: api/updatefrequencies 
        [HttpPost]
        public async Task<HttpStatusCode> PostDataTheme(UpdateFrequencyDTO UpdateFrequencyToPost)
        {
            var entity = new UpdateFrequency()
            {
                IdUpdateFrequency = UpdateFrequencyToPost.IdUpdateFrequency,
                UpdateFrequencyName = UpdateFrequencyToPost.UpdateFrequencyName
            };
            _context.UpdateFrequencies.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/updatefrequencies/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutUpdateFrequency(UpdateFrequencyDTO UpdateFrequencyToChange)
        {
            var entity = await _context.UpdateFrequencies.FirstOrDefaultAsync(u => u.IdUpdateFrequency == UpdateFrequencyToChange.IdUpdateFrequency);
            entity.IdUpdateFrequency = UpdateFrequencyToChange.IdUpdateFrequency;
            entity.UpdateFrequencyName = UpdateFrequencyToChange.UpdateFrequencyName;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //For HttpDelete look for cascade delete
        //DELETE: api/updatefrequencies/2
        /*[HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteUpdateFrequency(UpdateFrequencyDTO UpdateFrequencyToDelete)
        {
            var entity = new UpdateFrequency()
            {
                IdUpdateFrequency = UpdateFrequencyToDelete.IdUpdateFrequency
            };
            _context.UpdateFrequencies.Attach(entity);
            _context.UpdateFrequencies.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}
