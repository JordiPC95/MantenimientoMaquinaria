using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MantenimientoAPI.Data;
using MantenimientoAPI.Models;

namespace MantenimientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MantenimientosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> GetMantenimientos()
        {
            return await _context.Mantenimientos
                .Include(m => m.Tecnico)
                .Include(m => m.Maquinaria)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mantenimiento>> GetMantenimiento(int id)
        {
            var mantenimiento = await _context.Mantenimientos
                .Include(m => m.Tecnico)
                .Include(m => m.Maquinaria)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (mantenimiento == null) return NotFound();
            return mantenimiento;
        }

        [HttpPost]
        public async Task<ActionResult<Mantenimiento>> PostMantenimiento(Mantenimiento mantenimiento)
        {
            _context.Mantenimientos.Add(mantenimiento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMantenimiento), new { id = mantenimiento.ID }, mantenimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMantenimiento(int id, Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.ID) return BadRequest();

            _context.Entry(mantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Mantenimientos.Any(e => e.ID == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento(int id)
        {
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null) return NotFound();

            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
