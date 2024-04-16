﻿using System.ComponentModel.DataAnnotations;

namespace Questionario.Backend.Models
{
	public class FaixaSalarial
	{
		[Key]
		public int Id { get; set; }
		public string? Descricao { get; set; }
		public bool Ativo { get; set; }
	}
}