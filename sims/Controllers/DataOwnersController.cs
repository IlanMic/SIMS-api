using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sims.Data;
using sims.DTO;
using Sims.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace sims.Controllers
{
    [Route("api/dataowners")]
    [ApiController]
    public class DataOwnersController : ControllerBase
    {
        private readonly SimsContext _context;

        public DataOwnersController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/dataowners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataOwnerDTO>>> GetDataOwners()
        {
            var dataOwners = _context.DataOwners.ToList();
            var dataOwnersDTOs = new List<DataOwnerDTO>();
            foreach (var dataOwner in dataOwners)
            {
                dataOwnersDTOs.Add(new DataOwnerDTO
                {
                    IdDataOwner = dataOwner.IdDataOwner,
                    DataOwnerName = dataOwner.DataOwnerName
                });
            }
            return dataOwnersDTOs;
        }


        //GET: api/dataowners/2
        [HttpGet("{id}")]
        public async Task<ActionResult<DataOwnerDTO>> GetDataOwnerById(int id)
        {
            DataOwnerDTO DataOwner = await _context.DataOwners
                .Select(dataOwner => new DataOwnerDTO
                {
                    IdDataOwner = dataOwner.IdDataOwner,
                    DataOwnerName = dataOwner.DataOwnerName
                }).FirstOrDefaultAsync(dataOwner => dataOwner.IdDataOwner == id);
            if (DataOwner == null)
            {
                return NotFound();
            }
            else
            {
                return DataOwner;
            }
        }

        //POST: api/dataowners 
        [HttpPost]
        public async Task<HttpStatusCode> PostDataOwner(DataOwnerDTO DataOwnerToPost)
        {
            var entity = new DataOwner()
            {
                IdDataOwner = DataOwnerToPost.IdDataOwner,
                DataOwnerName = DataOwnerToPost.DataOwnerName
            };
            _context.DataOwners.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/dataowners/2
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutDataOwner(DataOwnerDTO DataOwnerToChange)
        {
            var entity = await _context.DataOwners.FirstOrDefaultAsync(u => u.IdDataOwner == DataOwnerToChange.IdDataOwner);
            entity.IdDataOwner = DataOwnerToChange.IdDataOwner;
            entity.DataOwnerName = DataOwnerToChange.DataOwnerName;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //For HttpDelete look for cascade delete
        //DELETE: api/dataowners/2
        /*[HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteDataOwner(DataOwnerDTO DataOwnerToDelete)
        {
            var entity = new DataOwner()
            {
                IdDataOwner = DataOwnerToDelete.IdDataOwner
            };
            _context.DataOwners.Attach(entity);
            _context.DataOwners.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}
