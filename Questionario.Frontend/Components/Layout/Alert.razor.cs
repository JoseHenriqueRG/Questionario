using Microsoft.AspNetCore.Components;

namespace Questionario.Frontend.Components.Layout
{
	public partial class Alert
	{
		[Parameter]
		public string Mensagem { get; set; }
		[Parameter]
		public string Classe { get; set; }
	}
}
