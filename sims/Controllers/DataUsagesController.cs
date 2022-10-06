using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sims.DTO;
using Sims.Data;
using Sims.Models;
using System.Net;

namespace sims.Controllers
{
    [Route("api/datausages")]
    [ApiController]
    public class DataUsagesController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataUsagesController(SimsContext context)
        {
            _context = context;
        }

        //GET: api/datausages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataUsageDTO>>> GetDataUsages()
        {
            var dataUsages = _context.DataUsages
                .Include(x => x.DataFormat)
                .Include(x => x.OpenData)
                .Include(x => x.OpenData.DataTheme)
                .Include(x => x.OpenData.DataOwner)
                .Include(x => x.OpenData.UpdateFrequency)
                .Include(x => x.Language)
                .Include(x => x.User)
                .Include(x => x.User.UserProfession)
                .Include(x => x.User.UserProfessionField)
                .ToList();
            var dataUsageDTOs = new List<DataUsageDTO>();
            foreach (var dataUsage in dataUsages)
            {
                dataUsageDTOs.Add(new DataUsageDTO
                {
                    IdDataUsage = dataUsage.IdDataUsage,
                    DateOfUsage = dataUsage.DateOfUsage,
                    IsDownloaded = dataUsage.IsDownloaded,
                    OpenData = dataUsage.OpenData == null ? null as OpenDatumDTO : new OpenDatumDTO
                    {
                        IdData = dataUsage.OpenData.IdData,
                        DataUrl = dataUsage.OpenData.DataUrl,
                        DataOpenLicense = dataUsage.OpenData.DataOpenLicense,
                        DataOwner = dataUsage.OpenData.DataOwner == null ? null as DataOwnerDTO : new DataOwnerDTO
                        {
                            IdDataOwner = dataUsage.OpenData.DataOwner.IdDataOwner,
                            DataOwnerName = dataUsage.OpenData.DataOwner.DataOwnerName
                        },
                        DataTheme = dataUsage.OpenData.DataTheme == null ? null as DataThemeDTO : new DataThemeDTO
                        {
                            IdDataTheme = dataUsage.OpenData.DataTheme.IdDataTheme,
                            DataThemeName = dataUsage.OpenData.DataTheme.DataThemeName
                        },
                        UpdateFrequency = dataUsage.OpenData.UpdateFrequency == null ? null as UpdateFrequencyDTO : new UpdateFrequencyDTO
                        {
                            IdUpdateFrequency = dataUsage.OpenData.UpdateFrequency.IdUpdateFrequency,
                            UpdateFrequencyName = dataUsage.OpenData.UpdateFrequency.UpdateFrequencyName
                        }
                    },
                    DataFormat = dataUsage.DataFormat == null ? null as DataFormatDTO : new DataFormatDTO
                    {
                        IdDataFormat = dataUsage.DataFormat.IdDataFormat,
                        DataFormatName = dataUsage.DataFormat.DataFormatName
                    },
                    Language = dataUsage.OpenData == null ? null as DataLanguageDTO : new DataLanguageDTO
                    {
                        IdDataLanguage = dataUsage.Language.IdDataLanguage,
                        DataLanguageName = dataUsage.Language.DataLanguageName
                    },
                    User = dataUsage.User == null ? null as UserDTO : new UserDTO
                    {
                        IdUser = dataUsage.User.IdUser,
                        UserName = dataUsage.User.UserName,
                        UserCompany = dataUsage.User.UserCompany,
                        UserMail = dataUsage.User.UserMail,
                        UserProfession = dataUsage.User.UserProfession == null ? null as ProfessionDTO : new ProfessionDTO
                        {
                            IdProfession = dataUsage.User.UserProfession.IdProfession,
                            ProfessionName = dataUsage.User.UserProfession.ProfessionName
                        },
                        UserProfessionField = dataUsage.User.UserProfessionField == null ? null as ProfessionFieldDTO : new ProfessionFieldDTO
                        {
                            IdProfessionField = dataUsage.User.UserProfessionField.IdProfessionField,
                            ProfessionFieldName = dataUsage.User.UserProfessionField.ProfessionFieldName
                        }

                    }
                });
            }
            return dataUsageDTOs;
        }

        //GET: api/datausages/2
        [HttpGet("{id}")]
        public async Task<ActionResult<DataUsageDTO>> GetDataUsageById(long id)
        {
            DataUsageDTO openData = await _context.DataUsages
                .Include(x => x.DataFormat)
                .Include(x => x.OpenData)
                .Include(x => x.OpenData.DataTheme)
                .Include(x => x.OpenData.DataOwner)
                .Include(x => x.OpenData.UpdateFrequency)
                .Include(x => x.Language)
                .Include(x => x.User)
                .Include(x => x.User.UserProfession)
                .Include(x => x.User.UserProfessionField)
                .Select(datausage => new DataUsageDTO
                {
                    IdDataUsage = datausage.IdDataUsage,
                    DateOfUsage = datausage.DateOfUsage,
                    IsDownloaded = datausage.IsDownloaded,
                    OpenData = datausage.OpenData == null ? null as OpenDatumDTO : new OpenDatumDTO
                    {
                        IdData = datausage.OpenData.IdData,
                        DataUrl = datausage.OpenData.DataUrl,
                        DataOpenLicense = datausage.OpenData.DataOpenLicense,
                        DataOwner = datausage.OpenData.DataOwner == null ? null as DataOwnerDTO : new DataOwnerDTO
                        {
                            IdDataOwner = datausage.OpenData.DataOwner.IdDataOwner,
                            DataOwnerName = datausage.OpenData.DataOwner.DataOwnerName
                        },
                        DataTheme = datausage.OpenData.DataTheme == null ? null as DataThemeDTO : new DataThemeDTO
                        {
                            IdDataTheme = datausage.OpenData.DataTheme.IdDataTheme,
                            DataThemeName = datausage.OpenData.DataTheme.DataThemeName
                        },
                        UpdateFrequency = datausage.OpenData.UpdateFrequency == null ? null as UpdateFrequencyDTO : new UpdateFrequencyDTO
                        {
                            IdUpdateFrequency = datausage.OpenData.UpdateFrequency.IdUpdateFrequency,
                            UpdateFrequencyName = datausage.OpenData.UpdateFrequency.UpdateFrequencyName
                        }
                    },
                    DataFormat = datausage.DataFormat == null ? null as DataFormatDTO : new DataFormatDTO
                    {
                        IdDataFormat = datausage.DataFormat.IdDataFormat,
                        DataFormatName = datausage.DataFormat.DataFormatName
                    },
                    Language = datausage.OpenData == null ? null as DataLanguageDTO : new DataLanguageDTO
                    {
                        IdDataLanguage = datausage.Language.IdDataLanguage,
                        DataLanguageName = datausage.Language.DataLanguageName
                    },
                    User = datausage.User == null ? null as UserDTO : new UserDTO
                    {
                        IdUser = datausage.User.IdUser,
                        UserName = datausage.User.UserName,
                        UserCompany = datausage.User.UserCompany,
                        UserMail = datausage.User.UserMail,
                        UserProfession = datausage.User.UserProfession == null ? null as ProfessionDTO : new ProfessionDTO
                        {
                            IdProfession = datausage.User.UserProfession.IdProfession,
                            ProfessionName = datausage.User.UserProfession.ProfessionName
                        },
                        UserProfessionField = datausage.User.UserProfessionField == null ? null as ProfessionFieldDTO : new ProfessionFieldDTO
                        {
                            IdProfessionField = datausage.User.UserProfessionField.IdProfessionField,
                            ProfessionFieldName = datausage.User.UserProfessionField.ProfessionFieldName
                        }

                    }
                }).FirstOrDefaultAsync(datausage => datausage.IdDataUsage == id);
            if (openData == null)
            {
                return NotFound();
            }
            else
            {
                return openData;
            }
        }

        //POST: api/datausages
        [HttpPost]
        public async Task<HttpStatusCode> PostDataUsage(DataUsageDTO DataUsageToPost)
        {
            var entity = new DataUsage()
            {
                IdDataUsage = DataUsageToPost.IdDataUsage,
                DateOfUsage = DataUsageToPost.DateOfUsage,
                IsDownloaded = DataUsageToPost.IsDownloaded,
                LanguageId = DataUsageToPost.Language.IdDataLanguage,
                DataFormatId = DataUsageToPost.DataFormat.IdDataFormat,
                UsedBy = DataUsageToPost.User.IdUser,
                OpenDataId = DataUsageToPost.OpenData.IdData
            };
            _context.DataUsages.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/datausages/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutDataUsage(DataUsageDTO DataUsageToChange)
        {
            var entity = await _context.DataUsages.FirstOrDefaultAsync(u => u.IdDataUsage == DataUsageToChange.IdDataUsage);
            entity.IdDataUsage = DataUsageToChange.IdDataUsage;
            entity.DateOfUsage = DataUsageToChange.DateOfUsage;
            entity.IsDownloaded = DataUsageToChange.IsDownloaded;
            entity.OpenDataId = DataUsageToChange.OpenData.IdData;
            entity.DataFormatId = DataUsageToChange.DataFormat.IdDataFormat;
            entity.UsedBy = DataUsageToChange.User.IdUser;
            entity.LanguageId = DataUsageToChange.Language.IdDataLanguage;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        /*
        //DELETE: api/datausages/2
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteDataUsage(DataUsageDTO DataUSageToDelete)
        {
            var entity = new DataUsage()
            {
                IdDataUsage = DataUSageToDelete.IdDataUsage
            };
            _context.DataUsages.Attach(entity);
            _context.DataUsages.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        */
    }
}
