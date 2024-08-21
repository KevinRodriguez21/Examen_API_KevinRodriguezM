using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_API_KevinRodriguezM.Models;
using Examen_API_KevinRodriguezM.ModelsDTOs;

namespace Examen_API_KevinRodriguezM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AnswersDbContext _context;

        public UsersController(AnswersDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("GetUserInfoByIdUser")]
        public ActionResult<IEnumerable<UsuarioDTO>> GetUserInfoByIdUser(int pUserId = 3 )
        {

            var query = (from u in _context.Users
                         join c in _context.Countries
                         on u.CountryId equals c.CountryId
                         join ur in _context.UserRoles
                         on u.UserRoleId equals ur.UserRoleId
                         join us in _context.UserStatuses
                         on u.UserStatusId equals us.UserStatusId
                         where u.UserId == pUserId
                         select new
                         {
                             id = u.UserId,
                             nombreusuario = u.UserName,
                             nombre = u.FirstName,
                             apellidos = u.LastName,
                             telefono = u.PhoneNumber,
                             contrassenia = u.UserPassword,
                             contarstrike = u.StrikeCount,
                             copiacorreo = u.BackUpEmail,
                             descripcciontrabajo = u.JobDescription,
                             idpais = u.CountryId,
                             nombrepais = c.CountryName,
                             idrolusuario = u.UserRoleId,
                             rolusuario = ur.UserRole1,
                             idestadousuario = u.UserStatusId,
                             estado = us.Status
                         }
                         ).ToList();


            List<UsuarioDTO> list = new List<UsuarioDTO>();


            foreach (var item in query)
            {
                UsuarioDTO nuevoUsuario = new UsuarioDTO()
                {
                    UserId = item.id,
                    NombreUsuario = item.nombreusuario,
                    Nombre = item.nombre,
                    Apellidos = item.apellidos,
                    Telefono = item.telefono,
                    Contrasennia = item.contrassenia,
                    StrikeConteo = item.contarstrike,
                    CorreoRespaldo = item.copiacorreo,
                    DescripcionTrabajo = item.descripcciontrabajo,
                    IdPais = item.idpais,
                    Pais = item.nombrepais,
                    IdRolUsuario = item.idrolusuario,
                    RolUsuario = item.rolusuario,
                    IdEstatusUsuario = item.idestadousuario,
                    EstatusUsuario = item.estado
                };

                list.Add(nuevoUsuario);
            }

            if (list == null) { return NotFound(); }

            return list;
        }



        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
