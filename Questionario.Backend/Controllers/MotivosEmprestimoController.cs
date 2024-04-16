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
    public class MotivosEmprestimoController : ControllerBase
    {
        private readonly QuestionarioBackendContext _context;

        public MotivosEmprestimoController(QuestionarioBackendContext context)
        {
            _context = context;
        }

        // GET: api/MotivosEmprestimo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotivoEmprestimo>>> GetMotivoEmprestimo()
        {
            return await _context.MotivoEmprestimo.Where(m => m.Ativo).ToListAsync();
        }

        // GET: api/MotivosEmprestimo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotivoEmprestimo>> GetMotivoEmprestimo(int id)
        {
            var motivoEmprestimo = await _context.MotivoEmprestimo.FindAsync(id);

            if (motivoEmprestimo == null)
            {
                return NotFound();
            }

            return motivoEmprestimo;
        }

        // PUT: api/MotivosEmprestimo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivoEmprestimo(int id, MotivoEmprestimo motivoEmprestimo)
        {
            if (id != motivoEmprestimo.Id)
            {
                return BadRequest();
            }

            _context.Entry(motivoEmprestimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivoEmprestimoExists(id))
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

        // POST: api/MotivosEmprestimo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MotivoEmprestimo>> PostMotivoEmprestimo(MotivoEmprestimo motivoEmprestimo)
        {
            _context.MotivoEmprestimo.Add(motivoEmprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivoEmprestimo", new { id = motivoEmprestimo.Id }, motivoEmprestimo);
        }

        // DELETE: api/MotivosEmprestimo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivoEmprestimo(int id)
        {
            var motivoEmprestimo = await _context.MotivoEmprestimo.FindAsync(id);
            if (motivoEmprestimo == null)
            {
                return NotFound();
            }

            _context.MotivoEmprestimo.Remove(motivoEmprestimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotivoEmprestimoExists(int id)
        {
            return _context.MotivoEmprestimo.Any(e => e.Id == id);
        }
    }
}
