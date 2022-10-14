using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sims.Data;
using sims.DTO;
using Sims.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace sims.Controllers
{
    [Route("api/datathemes")]
    [ApiController]
    public class DataThemesController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataThemesController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/datathemes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataThemeDTO>>> GetDataThemes()
        {
            var dataThemes = _context.DataThemes.ToList();
            var dataThemeDTOs = new List<DataThemeDTO>();
            foreach (var dataTheme in dataThemes)
            {
                dataThemeDTOs.Add(new DataThemeDTO
                {
                    IdDataTheme = dataTheme.IdDataTheme,
                    DataThemeName = dataTheme.DataThemeName
                });
            }
            return dataThemeDTOs;
        }


        //GET: api/datathemes/2
        [HttpGet("{id}")]
        public async Task<ActionResult<DataThemeDTO>> GetDataThemeById(int id)
        {
            DataThemeDTO DataTheme = await _context.DataThemes
                .Select(dataTheme => new DataThemeDTO
                {
                    IdDataTheme = dataTheme.IdDataTheme,
                    DataThemeName = dataTheme.DataThemeName
                }).FirstOrDefaultAsync(dataTheme => dataTheme.IdDataTheme == id);
            if (DataTheme == null)
            {
                return NotFound();
            }
            else
            {
                return DataTheme;
            }
        }

        //POST: api/datathemes 
        [HttpPost]
        public async Task<HttpStatusCode> PostDataTheme(DataThemeDTO DataThemeToPost)
        {
            var entity = new DataTheme()
            {
                IdDataTheme = DataThemeToPost.IdDataTheme,
                DataThemeName = DataThemeToPost.DataThemeName
            };
            _context.DataThemes.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/datathemes/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutDataTheme(DataThemeDTO DataThemeToChange)
        {
            var entity = await _context.DataThemes.FirstOrDefaultAsync(u => u.IdDataTheme == DataThemeToChange.IdDataTheme);
            entity.IdDataTheme = DataThemeToChange.IdDataTheme;
            entity.DataThemeName = DataThemeToChange.DataThemeName;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //For HttpDelete look for cascade delete
        //DELETE: api/datathemes/2
        /*[HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteDataTheme(DataThemeDTO DataThemeToDelete)
        {
            var entity = new DataTheme()
            {
                IdDataTheme = DataThemeToDelete.IdDataTheme
            };
            _context.DataThemes.Attach(entity);
            _context.DataThemes.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}
