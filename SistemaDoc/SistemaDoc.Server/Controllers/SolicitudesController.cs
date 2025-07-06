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
        public async Task<IEnumerable<Solicitud>> Get() => await _context.Solicitudes.ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Solicitud solicitud)
        {
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
            return Ok(solicitud);
        }
    }

}
