using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Questionario.Backend.Data;
using Questionario.Backend.Models;

namespace Questionario.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostasController : ControllerBase
    {
        private readonly QuestionarioBackendContext _context;

        public RespostasController(QuestionarioBackendContext context)
        {
            _context = context;
        }

        // GET: api/Respostas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resposta>> GetResposta(int id)
        {
            var resposta = await _context.Resposta.FindAsync(id);

            if (resposta == null)
            {
                return NotFound();
            }

            return resposta;
        }

        // POST: api/Respostas
        [HttpPost]
        public async Task<ActionResult<Resposta>> PostResposta(Resposta resposta)
        {
            try
            {
				_context.Entry(resposta.FaixaIdade).State = EntityState.Unchanged;
				_context.Entry(resposta.FaixaSalarial).State = EntityState.Unchanged;
				_context.Entry(resposta.Convenio).State = EntityState.Unchanged;
				_context.Entry(resposta.MotivoEmprestimo).State = EntityState.Unchanged;

				_context.Resposta.Add(resposta);

                var id = await _context.SaveChangesAsync();

                return CreatedAtAction("GetResposta", new { id = resposta.Id }, resposta);
            }
            catch (Exception ex)
            {
				// Log(ex.Message);
				return StatusCode(500, "Ocorreu um erro interno.");
            }
        }
    }
}
