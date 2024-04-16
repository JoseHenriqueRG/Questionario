using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questionario.Backend.Models;

namespace Questionario.Backend.Data
{
    public class QuestionarioBackendContext : DbContext
    {
        public QuestionarioBackendContext (DbContextOptions<QuestionarioBackendContext> options)
            : base(options)
        {
        }

        public DbSet<Questionario.Backend.Models.Resposta> Resposta { get; set; } = default!;
        public DbSet<Questionario.Backend.Models.MotivoEmprestimo> MotivoEmprestimo { get; set; } = default!;
        public DbSet<Questionario.Backend.Models.FaixaSalarial> FaixaSalarial { get; set; } = default!;
        public DbSet<Questionario.Backend.Models.FaixaIdade> FaixaIdade { get; set; } = default!;
        public DbSet<Questionario.Backend.Models.Convenio> Convenio { get; set; } = default!;
    }
}
