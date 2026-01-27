using LigaDS.Data;
using LigaDS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LigaDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private readonly LigaDbContext _context;

        public AtletaController(LigaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAtletasAsync()
        {
            var atletas = _context.Atletas.ToList();
            return Ok(atletas);
        }

        [HttpPost]
        public async Task<IActionResult> AddAtleta([FromBody] Atleta atleta)
        {
            _context.Atletas.Add(atleta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllAtletasAsync), new { id = atleta.Id }, atleta);
        }
    }
}
