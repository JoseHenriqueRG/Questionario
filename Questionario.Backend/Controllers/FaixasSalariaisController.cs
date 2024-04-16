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
    public class FaixasSalariaisController : ControllerBase
    {
        private readonly QuestionarioBackendContext _context;

        public FaixasSalariaisController(QuestionarioBackendContext context)
        {
            _context = context;
        }

        // GET: api/FaixasSalariais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaixaSalarial>>> GetFaixaSalarial()
        {
            return await _context.FaixaSalarial.Where(m => m.Ativo).ToListAsync();
        }

        // GET: api/FaixasSalariais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FaixaSalarial>> GetFaixaSalarial(int id)
        {
            var faixaSalarial = await _context.FaixaSalarial.FindAsync(id);

            if (faixaSalarial == null)
            {
                return NotFound();
            }

            return faixaSalarial;
        }

        // PUT: api/FaixasSalariais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaixaSalarial(int id, FaixaSalarial faixaSalarial)
        {
            if (id != faixaSalarial.Id)
            {
                return BadRequest();
            }

            _context.Entry(faixaSalarial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaixaSalarialExists(id))
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

        // POST: api/FaixasSalariais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FaixaSalarial>> PostFaixaSalarial(FaixaSalarial faixaSalarial)
        {
            _context.FaixaSalarial.Add(faixaSalarial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaixaSalarial", new { id = faixaSalarial.Id }, faixaSalarial);
        }

        // DELETE: api/FaixasSalariais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaixaSalarial(int id)
        {
            var faixaSalarial = await _context.FaixaSalarial.FindAsync(id);
            if (faixaSalarial == null)
            {
                return NotFound();
            }

            _context.FaixaSalarial.Remove(faixaSalarial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaixaSalarialExists(int id)
        {
            return _context.FaixaSalarial.Any(e => e.Id == id);
        }
    }
}
