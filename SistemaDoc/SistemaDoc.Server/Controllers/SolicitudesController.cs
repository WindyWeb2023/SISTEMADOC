using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDoc.Server.Data;
using SistemaDoc.Shared.Models;

namespace SistemaDoc.Server.Controllers
{
    // Server/Controllers/SolicitudesController.cs
    [ApiController]
    [Route("api/Solicitudes")]
    public class SolicitudesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SolicitudesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SolicitudDTO>>> GetSolicitudesDTO()
        {
            var lista = await _context.Solicitudes
                .Include(s => s.Area)
                .Include(s=>s.Categoria)
                .Select(s => new SolicitudDTO
                {
                    Id = s.Id,
                    NombreSolicitante = s.NombreSolicitante,
                    Referencia = s.Referencia,
                    FechaSolicitud = s.FechaSolicitud,
                    Observaciones=s.Observaciones,
                    Estado = s.Estado,
                    NombreArea = s.Area.Nombre,
                    NombreCategoria=s.Categoria.Name
                })
                .ToListAsync();

            return lista;
        }
        [HttpGet("{cargo}")]
        public async Task<ActionResult<List<SolicitudDTO>>> GetSolicitudesDTOp(string cargo)
        {
            // Buscar el usuario
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Cargo == cargo);

            if (user == null)
                return Unauthorized();

            // Filtrar por el área igual al cargo/rol
            var lista = await _context.Solicitudes
                .Include(s => s.Area)
                .Include(s => s.Categoria)
                .Where(s => s.Area.Nombre == user.Cargo) // o .AreaId == user.AreaId
                .Select(s => new SolicitudDTO
                {
                    Id = s.Id,
                    NombreSolicitante = s.NombreSolicitante,
                    Referencia = s.Referencia,
                    FechaSolicitud = s.FechaSolicitud,
                    Observaciones = s.Observaciones,
                    Estado = s.Estado,
                    NombreArea = s.Area.Nombre,
                    NombreCategoria = s.Categoria.Name
                })
                .ToListAsync();

            return lista;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Solicitud solicitud)
        {
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
            return Ok(solicitud);
        }
    }

}
