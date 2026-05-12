using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serveur.Data;
using serveur.Models;

namespace serveur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenusController : ControllerBase
    {
        private readonly serveurContext _context;

        public RevenusController(serveurContext context)
        {
            _context = context;
        }

        // GET: api/Revenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revenu>>> GetRevenu()
        {
            return await _context.Revenu.ToListAsync();
        }

        // GET: api/Revenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Revenu>> GetRevenu(int id)
        {
            var revenu = await _context.Revenu.FindAsync(id);

            if (revenu == null)
            {
                return NotFound();
            }

            return revenu;
        }

        // PUT: api/Revenus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevenu(int id, Revenu revenu)
        {
            if (id != revenu.id)
            {
                return BadRequest();
            }

            _context.Entry(revenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevenuExists(id))
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

        // POST: api/Revenus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Revenu>> PostRevenu(Revenu revenu)
        {
            _context.Revenu.Add(revenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRevenu", new { id = revenu.id }, revenu);
        }

        // DELETE: api/Revenus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevenu(int id)
        {
            var revenu = await _context.Revenu.FindAsync(id);
            if (revenu == null)
            {
                return NotFound();
            }

            _context.Revenu.Remove(revenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RevenuExists(int id)
        {
            return _context.Revenu.Any(e => e.id == id);
        }
    }
}
