using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sims.Data;
using sims.DTO;
using Sims.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace sims.Controllers
{
    [Route("api/datalanguages")]
    [ApiController]
    public class DataLanguagesController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataLanguagesController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/datalanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataLanguageDTO>>> GetDataLanguages()
        {
            var dataLanguages = _context.DataLanguages.ToList();
            var dataLanguageDTOs = new List<DataLanguageDTO>();
            foreach (var dataLanguage in dataLanguages)
            {
                dataLanguageDTOs.Add(new DataLanguageDTO
                {
                    IdDataLanguage = dataLanguage.IdDataLanguage,
                    DataLanguageName = dataLanguage.DataLanguageName
                });
            }
            return dataLanguageDTOs;
        }


        //GET: api/datalanguages/2
        [HttpGet("{id}")]
        public async Task<ActionResult<DataLanguageDTO>> GetDataLanguageById(int id)
        {
            DataLanguageDTO DataLanguage = await _context.DataLanguages
                .Select(dataLanguage => new DataLanguageDTO
                {
                    IdDataLanguage = dataLanguage.IdDataLanguage,
                    DataLanguageName = dataLanguage.DataLanguageName
                }).FirstOrDefaultAsync(dataLanguage => dataLanguage.IdDataLanguage == id);
            if (DataLanguage == null)
            {
                return NotFound();
            }
            else
            {
                return DataLanguage;
            }
        }

        //POST: api/datalanguages 
        [HttpPost]
        public async Task<HttpStatusCode> PostDataLanguage(DataLanguageDTO DataLanguageToPost)
        {
            var entity = new DataLanguage()
            {
                IdDataLanguage = DataLanguageToPost.IdDataLanguage,
                DataLanguageName= DataLanguageToPost.DataLanguageName
            };
            _context.DataLanguages.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/datalanguages/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutDataLanguage(DataLanguageDTO DataLanguageToChange)
        {
            var entity = await _context.DataLanguages.FirstOrDefaultAsync(u => u.IdDataLanguage == DataLanguageToChange.IdDataLanguage);
            entity.IdDataLanguage = DataLanguageToChange.IdDataLanguage;
            entity.DataLanguageName = DataLanguageToChange.DataLanguageName;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //For HttpDelete look for cascade delete
        //DELETE: api/datalanguages/2
        /*[HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteDataLanguage(DataLanguageDTO DataLanguageToDelete)
        {
            var entity = new DataLanguage()
            {
                IdDataLanguage = DataLanguageToDelete.IdDataLanguage
            };
            _context.DataLanguages.Attach(entity);
            _context.DataLanguages.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}
