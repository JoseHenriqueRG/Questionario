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
    public class ConveniosController : ControllerBase
    {
        private readonly QuestionarioBackendContext _context;

        public ConveniosController(QuestionarioBackendContext context)
        {
            _context = context;
        }

        // GET: api/Convenios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Convenio>>> GetConvenio()
        {
            return await _context.Convenio.Where(m => m.Ativo).ToListAsync();
        }

        // GET: api/Convenios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Convenio>> GetConvenio(int id)
        {
            var convenio = await _context.Convenio.FindAsync(id);

            if (convenio == null)
            {
                return NotFound();
            }

            return convenio;
        }

        // PUT: api/Convenios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConvenio(int id, Convenio convenio)
        {
            if (id != convenio.Id)
            {
                return BadRequest();
            }

            _context.Entry(convenio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConvenioExists(id))
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

        // POST: api/Convenios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Convenio>> PostConvenio(Convenio convenio)
        {
            _context.Convenio.Add(convenio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConvenio", new { id = convenio.Id }, convenio);
        }

        // DELETE: api/Convenios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConvenio(int id)
        {
            var convenio = await _context.Convenio.FindAsync(id);
            if (convenio == null)
            {
                return NotFound();
            }

            _context.Convenio.Remove(convenio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConvenioExists(int id)
        {
            return _context.Convenio.Any(e => e.Id == id);
        }
    }
}
