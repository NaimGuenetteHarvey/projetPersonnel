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
    public class InvestissementsController : ControllerBase
    {
        private readonly serveurContext _context;

        public InvestissementsController(serveurContext context)
        {
            _context = context;
        }

        // GET: api/Investissements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investissement>>> GetInvestissement()
        {
            return await _context.Investissement.ToListAsync();
        }

        // GET: api/Investissements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investissement>> GetInvestissement(int id)
        {
            var investissement = await _context.Investissement.FindAsync(id);

            if (investissement == null)
            {
                return NotFound();
            }

            return investissement;
        }

        // PUT: api/Investissements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestissement(int id, Investissement investissement)
        {
            if (id != investissement.id)
            {
                return BadRequest();
            }

            _context.Entry(investissement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestissementExists(id))
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

        // POST: api/Investissements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Investissement>> PostInvestissement(Investissement investissement)
        {
            _context.Investissement.Add(investissement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestissement", new { id = investissement.id }, investissement);
        }

        // DELETE: api/Investissements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestissement(int id)
        {
            var investissement = await _context.Investissement.FindAsync(id);
            if (investissement == null)
            {
                return NotFound();
            }

            _context.Investissement.Remove(investissement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestissementExists(int id)
        {
            return _context.Investissement.Any(e => e.id == id);
        }
    }
}
