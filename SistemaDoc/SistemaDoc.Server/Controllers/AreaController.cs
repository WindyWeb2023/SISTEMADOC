using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDoc.Server.Data;
using SistemaDoc.Shared.Models;

namespace SistemaDoc.Server.Controllers
{
    [ApiController]
    [Route("api/Areas")]
    public class AreaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AreaController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Area>>> GetArea()
        {
            return await _context.Area.ToListAsync();
        }
    }
}
