﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Questionario.Backend.Models
{
	public class Resposta
	{
		[Key]
		public int Id { get; set; }
		public FaixaIdade FaixaIdade { get; set; }
		public Convenio Convenio { get; set; }
		public FaixaSalarial FaixaSalarial { get; set; }
		public MotivoEmprestimo MotivoEmprestimo { get; set; }
	}
}