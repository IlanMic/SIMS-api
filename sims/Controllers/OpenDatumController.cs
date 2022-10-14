using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sims.DTO;
using Sims.Data;
using Sims.Models;
using System.Net;

namespace sims.Controllers
{
    [Route("api/opendatum")]
    [ApiController]
    public class OpenDatumController : ControllerBase
    {
        private readonly SimsContext _context;

        public OpenDatumController(SimsContext context)
        {
            _context = context;
        }

        //GET: api/opendatum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpenDatumDTO>>> GetData()
        {
            var openDatum = _context.OpenData
                .Include(x => x.DataOwner)
                .Include(x => x.DataTheme)
                .Include(x => x.UpdateFrequency)
                .ToList();
            var openDatumDTOs = new List<OpenDatumDTO>();
            foreach (var opendata in openDatum)
            {
                openDatumDTOs.Add(new OpenDatumDTO
                {
                    IdData = opendata.IdData,
                    DataUrl = opendata.DataUrl,
                    DataOpenLicense = opendata.DataOpenLicense,
                    DataOwner = opendata.DataOwner == null ? null as DataOwnerDTO : new DataOwnerDTO
                    {
                        IdDataOwner = opendata.DataOwner.IdDataOwner,
                        DataOwnerName = opendata.DataOwner.DataOwnerName
                    },
                    DataTheme = opendata.DataTheme == null ? null as DataThemeDTO : new DataThemeDTO
                    {
                        IdDataTheme = opendata.DataTheme.IdDataTheme,
                        DataThemeName = opendata.DataTheme.DataThemeName
                    },
                    UpdateFrequency = opendata.UpdateFrequency == null ? null as UpdateFrequencyDTO : new UpdateFrequencyDTO
                    {
                        IdUpdateFrequency = opendata.UpdateFrequency.IdUpdateFrequency,
                        UpdateFrequencyName = opendata.UpdateFrequency.UpdateFrequencyName
                    }
                });
            }
            return openDatumDTOs;
        }

        //GET: api/opendatum/2
        [HttpGet("{id}")]
        public async Task<ActionResult<OpenDatumDTO>> GetDataById(long id)
        {
            OpenDatumDTO openData = await _context.OpenData
                .Include(x => x.DataOwner)
                .Include(x => x.DataTheme)
                .Include(x => x.UpdateFrequency)
                .Select(opendata => new OpenDatumDTO
                {
                    IdData = opendata.IdData,
                    DataUrl = opendata.DataUrl,
                    DataOpenLicense = opendata.DataOpenLicense,
                    DataOwner = opendata.DataOwner == null ? null as DataOwnerDTO : new DataOwnerDTO
                    {
                        IdDataOwner = opendata.DataOwner.IdDataOwner,
                        DataOwnerName = opendata.DataOwner.DataOwnerName
                    },
                    DataTheme = opendata.DataTheme == null ? null as DataThemeDTO : new DataThemeDTO
                    {
                        IdDataTheme = opendata.DataTheme.IdDataTheme,
                        DataThemeName = opendata.DataTheme.DataThemeName
                    },
                    UpdateFrequency = opendata.UpdateFrequency == null ? null as UpdateFrequencyDTO : new UpdateFrequencyDTO
                    {
                        IdUpdateFrequency = opendata.UpdateFrequency.IdUpdateFrequency,
                        UpdateFrequencyName = opendata.UpdateFrequency.UpdateFrequencyName
                    }
                }).FirstOrDefaultAsync(openData => openData.IdData == id);
            if (openData == null)
            {
                return NotFound();
            }
            else
            {
                return openData;
            }
        }

        //POST: api/opendatum
        [HttpPost]
        public async Task<HttpStatusCode> PostOpenData(OpenDatumDTO OpenDatatoPost)
        {
            var entity = new OpenDatum()
            {
                IdData = OpenDatatoPost.IdData,
                DataUrl = OpenDatatoPost.DataUrl,
                DataOpenLicense = OpenDatatoPost.DataOpenLicense,
                DataOwnerId = OpenDatatoPost.DataOwner.IdDataOwner,
                DataThemeId = OpenDatatoPost.DataTheme.IdDataTheme,
                UpdateFrequencyId = OpenDatatoPost.UpdateFrequency.IdUpdateFrequency
            };
            _context.OpenData.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/opendatum/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutData(OpenDatumDTO DataToChange)
        {
            var entity = await _context.OpenData.FirstOrDefaultAsync(u => u.IdData == DataToChange.IdData);
            entity.IdData = DataToChange.IdData;
            entity.DataUrl = DataToChange.DataUrl;
            entity.DataOpenLicense = DataToChange.DataOpenLicense;
            entity.DataOwnerId = DataToChange.DataOwner.IdDataOwner;
            entity.DataThemeId = DataToChange.DataTheme.IdDataTheme;
            entity.UpdateFrequencyId = DataToChange.UpdateFrequency.IdUpdateFrequency;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        /*
        //DELETE: api/opendatum/2
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteData(OpenDatumDTO DataToDelete)
        {
            var entity = new OpenDatum()
            {
                IdData = DataToDelete.IdData
            };
            _context.OpenData.Attach(entity);
            _context.OpenData.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}
