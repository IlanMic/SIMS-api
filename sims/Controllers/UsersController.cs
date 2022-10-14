using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sims.DTO;
using Sims.Data;
using Sims.Models;
using System.Net;

namespace sims.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SimsContext _context;

        public UsersController(SimsContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = _context.Users
                .Include(x => x.UserProfession)
                .Include(x=> x.UserProfessionField)
                .ToList();
            var userDtos = new List<UserDTO>();
            foreach (var user in users)
            {
                userDtos.Add(new UserDTO 
                { 
                    IdUser = user.IdUser, 
                    UserName = user.UserName, 
                    UserCompany = user.UserCompany, 
                    UserMail = user.UserMail, 
                    UserProfession =  user.UserProfession == null ? null as ProfessionDTO : new ProfessionDTO
                    {
                        IdProfession = user.UserProfession.IdProfession,
                        ProfessionName = user.UserProfession.ProfessionName
                    },
                    UserProfessionField = user.UserProfessionField == null ? null as ProfessionFieldDTO : new ProfessionFieldDTO
                    {
                        IdProfessionField = user.UserProfessionField.IdProfessionField,
                        ProfessionFieldName = user.UserProfessionField.ProfessionFieldName
                    }
                });
            }
            return userDtos;
        }


        //GET: api/user/2
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(long id)
        {
            UserDTO User = await _context.Users
                .Include(x => x.UserProfession)
                .Include(x => x.UserProfessionField)
                .Select(user => new UserDTO
            {
                IdUser = user.UserProfessionId,
                UserName = user.UserName,
                UserCompany = user.UserCompany,
                UserMail = user.UserMail,
                UserProfession = user.UserProfession == null ?
                    null as ProfessionDTO : new ProfessionDTO
                    {
                        IdProfession = user.UserProfession.IdProfession,
                        ProfessionName = user.UserProfession.ProfessionName
                    },
                UserProfessionField = user.UserProfessionField == null ?
                    null as ProfessionFieldDTO : new ProfessionFieldDTO
                    {
                        IdProfessionField = user.UserProfessionField.IdProfessionField,
                        ProfessionFieldName = user.UserProfessionField.ProfessionFieldName
                    }
            }).FirstOrDefaultAsync(user => user.IdUser == id);
            if(User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }

        //POST: api/user 
        [HttpPost]
        public async Task<HttpStatusCode> PostUser(UserDTO UserToPost)
        {
            var entity = new User()
            {
                IdUser = UserToPost.IdUser,
                UserName = UserToPost.UserName,
                UserCompany = UserToPost.UserCompany,
                UserMail = UserToPost.UserMail,
                UserProfessionId = UserToPost.UserProfession.IdProfession,
                UserProfessionFieldId = UserToPost.UserProfessionField.IdProfessionField
            };
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //PUT: api/user/2
        [HttpPut("{id}")]
        public async Task <HttpStatusCode> PutUser(UserDTO UserToChange)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == UserToChange.IdUser);
            entity.IdUser = UserToChange.IdUser;
            entity.UserName = UserToChange.UserName;
            entity.UserMail = UserToChange.UserMail;
            entity.UserCompany = UserToChange.UserCompany;
            entity.UserProfessionId = UserToChange.UserProfession.IdProfession;
            entity.UserProfessionFieldId = UserToChange.UserProfessionField.IdProfessionField;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //For HttpDelete look for cascade delete
        //DELETE: api/user/2
        /*[HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteUser(UserDTO UserToDelete)
        {
            var entity = new User()
            {
                IdUser = UserToDelete.IdUser
            };
            _context.Users.Attach(entity);
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }*/
    }
}
