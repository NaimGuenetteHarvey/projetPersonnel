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
    public class DépenseController : ControllerBase
    {
        private readonly serveurContext _context;

        public DépenseController(serveurContext context)
        {
            _context = context;
        }

        // GET: api/Dépense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dépense>>> GetDépense()
        {
            return await _context.Dépense.ToListAsync();
        }

        // GET: api/Dépense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dépense>> GetDépense(int id)
        {
            var dépense = await _context.Dépense.FindAsync(id);

            if (dépense == null)
            {
                return NotFound();
            }

            return dépense;
        }

        // PUT: api/Dépense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDépense(int id, Dépense dépense)
        {
            if (id != dépense.Id)
            {
                return BadRequest();
            }

            _context.Entry(dépense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DépenseExists(id))
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

        // POST: api/Dépense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dépense>> PostDépense(Dépense dépense)
        {
            _context.Dépense.Add(dépense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDépense", new { id = dépense.Id }, dépense);
        }

        // DELETE: api/Dépense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDépense(int id)
        {
            var dépense = await _context.Dépense.FindAsync(id);
            if (dépense == null)
            {
                return NotFound();
            }

            _context.Dépense.Remove(dépense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DépenseExists(int id)
        {
            return _context.Dépense.Any(e => e.Id == id);
        }
    }
}
