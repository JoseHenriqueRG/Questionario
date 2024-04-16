using System.ComponentModel.DataAnnotations;

namespace Questionario.Backend.Models
{
	public class Convenio
	{
		[Key]
		public int Id { get; set; }
		public string? Nome { get; set; }
		public bool Ativo { get; set; }
	}
}