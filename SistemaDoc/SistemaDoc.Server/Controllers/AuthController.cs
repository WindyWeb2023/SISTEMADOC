using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDoc.Server.Data;
using SistemaDoc.Shared.Models;

namespace SistemaDoc.Server.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] Usuario credenciales)
        {
            var user = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.NombreUsuario == credenciales.NombreUsuario && u.Contrasena == credenciales.Contrasena );
            
            if (user == null)
                return Unauthorized("Credenciales incorrectas.");

            return Ok(user); // Devolvemos el usuario completo (sin token)
        }


        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(Usuario nuevo)
        {
            var existe = await _context.Usuarios.AnyAsync(u => u.NombreUsuario == nuevo.NombreUsuario);
            if (existe)
                return BadRequest("Usuario ya existe.");

            _context.Usuarios.Add(nuevo);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

}
