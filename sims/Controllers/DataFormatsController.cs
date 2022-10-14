using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sims.Data;
using sims.DTO;
using Sims.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace sims.Controllers
{
    [Route("api/dataformats")]
    [ApiController]
    public class DataFormatsController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataFormatsController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/dataformats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataFormatDTO>>> GetDataFormats()
        {
            var dataFormats = _context.DataFormats.ToList();
            var dataFormatsDTOs = new List<DataFormatDTO>();
            foreach (var dataFormat in dataFormats)
            {
                dataFormatsDTOs.Add(new DataFormatDTO
                {
                    IdDataFormat = dataFormat.IdDataFormat,
                    DataFormatName = dataFormat.DataFormatName
                });
            }
            return dataFormatsDTOs;
        }


        //GET: api/dataformats/2
        [HttpGet("{id}")]
        public async Task<ActionResult<DataFormatDTO>> GetDataFormatById(int id)
        {
            DataFormatDTO DataFormat = await _context.DataFormats
                .Select(dataFormat => new DataFormatDTO
                {
                    IdDataFormat = dataFormat.IdDataFormat,
                    DataFormatName = dataFormat.DataFormatName
                }).FirstOrDefaultAsync(dataFormat => dataFormat.IdDataFormat == id);
            if (DataFormat == null)
            {
                return NotFound();
            }
            else
            {
                return DataFormat;
            }
        }

        //POST: api/dataformats 
        [HttpPost]
        public async Task<HttpStatusCode> PostDataFormat(DataFormatDTO DataFormatToPost)
        {
            var entity = new DataFormat()
            {
                IdDataFormat = DataFormatToPost.IdDataFormat,
                DataFormatName = DataFormatToPost.DataFormatName
            };
            _context.DataFormats.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/dataformats/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutDataFormat(DataFormatDTO DataFormatToChange)
        {
            var entity = await _context.DataFormats.FirstOrDefaultAsync(u => u.IdDataFormat == DataFormatToChange.IdDataFormat);
            entity.IdDataFormat = DataFormatToChange.IdDataFormat;
            entity.DataFormatName = DataFormatToChange.DataFormatName;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //For HttpDelete look for cascade delete
        //DELETE: api/dataformats/2
        /*[HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteDataFormat(DataFormatDTO DataFormatToDelete)
        {
            var entity = new DataFormat()
            {
                IdDataFormat = DataFormatToDelete.IdDataFormat
            };
            _context.DataFormats.Attach(entity);
            _context.DataFormats.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}

