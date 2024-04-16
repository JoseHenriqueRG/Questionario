using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionario.Backend.Data;
using Questionario.Backend.Models;

namespace Questionario.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaixasIdadesController : ControllerBase
    {
        private readonly QuestionarioBackendContext _context;

        public FaixasIdadesController(QuestionarioBackendContext context)
        {
            _context = context;
        }

        // GET: api/FaixasIdades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaixaIdade>>> GetFaixaIdade()
        {
            return await _context.FaixaIdade.Where(m => m.Ativo).ToListAsync();
        }

        // GET: api/FaixasIdades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FaixaIdade>> GetFaixaIdade(int id)
        {
            var faixaIdade = await _context.FaixaIdade.FindAsync(id);

            if (faixaIdade == null)
            {
                return NotFound();
            }

            return faixaIdade;
        }

        // PUT: api/FaixasIdades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaixaIdade(int id, FaixaIdade faixaIdade)
        {
            if (id != faixaIdade.Id)
            {
                return BadRequest();
            }

            _context.Entry(faixaIdade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaixaIdadeExists(id))
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

        // POST: api/FaixasIdades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FaixaIdade>> PostFaixaIdade(FaixaIdade faixaIdade)
        {
            _context.FaixaIdade.Add(faixaIdade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaixaIdade", new { id = faixaIdade.Id }, faixaIdade);
        }

        // DELETE: api/FaixasIdades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaixaIdade(int id)
        {
            var faixaIdade = await _context.FaixaIdade.FindAsync(id);
            if (faixaIdade == null)
            {
                return NotFound();
            }

            _context.FaixaIdade.Remove(faixaIdade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaixaIdadeExists(int id)
        {
            return _context.FaixaIdade.Any(e => e.Id == id);
        }
    }
}
