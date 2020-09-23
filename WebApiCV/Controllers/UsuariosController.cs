using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApiCV.Contexto;
using WebApiCV.Model;

namespace WebApiCV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public string GereteToken()

        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6Ikpva"));

            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(

                 expires: DateTime.Now.AddMinutes(1),

                 signingCredentials: signInCred

             );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            // _context.Usuarios.Add(usuario);
            // await _context.SaveChangesAsync();
            //if (!_context.Usuarios.Any(e => e.Email == usuario.Email))
            //{
            //    if (!_context.Usuarios.Any(e => e.Cpf == usuario.Cpf))
            //    {
            //        _context.Usuarios.Add(usuario);
            //        await _context.SaveChangesAsync();
                   
            //    }
            //    else
            //    {
            //        return NotFound("Cpf existente");
            //    }
            //}
            //else
            //{
            //    return NotFound("Email existente");
            //}
           
           
           

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // Deletar: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
