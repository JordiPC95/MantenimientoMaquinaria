using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MantenimientoAPI.Data;
using MantenimientoAPI.Models;

namespace MantenimientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinariaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaquinariaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquinaria>>> GetMaquinarias()
        {
            return await _context.Maquinarias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maquinaria>> GetMaquinaria(int id)
        {
            var maquinaria = await _context.Maquinarias.FindAsync(id);
            if (maquinaria == null) return NotFound();
            return maquinaria;
        }

        [HttpPost]
        public async Task<ActionResult<Maquinaria>> PostMaquinaria(Maquinaria maquinaria)
        {
            _context.Maquinarias.Add(maquinaria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMaquinaria), new { id = maquinaria.ID }, maquinaria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquinaria(int id, Maquinaria maquinaria)
        {
            if (id != maquinaria.ID) return BadRequest();

            _context.Entry(maquinaria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Maquinarias.Any(e => e.ID == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaquinaria(int id)
        {
            var maquinaria = await _context.Maquinarias.FindAsync(id);
            if (maquinaria == null) return NotFound();

            _context.Maquinarias.Remove(maquinaria);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
