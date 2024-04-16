namespace Questionario.Frontend.Models
{
	public class Resposta
	{
		public int Id { get; set; }
		public FaixaIdade FaixaIdade { get; set; }
		public Convenio Convenio { get; set; }
		public FaixaSalarial FaixaSalarial { get; set; }
		public MotivoEmprestimo MotivoEmprestimo { get; set; }
	}
}
