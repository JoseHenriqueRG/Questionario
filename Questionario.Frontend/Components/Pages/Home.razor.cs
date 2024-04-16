using Microsoft.AspNetCore.Components;
using Questionario.Frontend.Components.Layout;
using Questionario.Frontend.Models;
using Questionario.Frontend.Services;

namespace Questionario.Frontend.Components.Pages
{
	public partial class Home
	{
		[Inject]
		public IQuestionario<Convenio> _convenioService { get; set; }
		[Inject]
		public IQuestionario<FaixaIdade> _faixaIdadeService { get; set; }
		[Inject]
		public IQuestionario<FaixaSalarial> _faixaSalarialService { get; set; }
		[Inject]
		public IQuestionario<MotivoEmprestimo> _motivoEmprestimoService { get; set; }
		[Inject]
		public IResposta respostaService { get; set; }

		private Resposta _resposta { get; set; } = new();
		private IList<Convenio>? _convenios { get; set; } = [];
		private IList<FaixaIdade>? _faixasIdade { get; set; } = [];
		private IList<FaixaSalarial>? _faixasSalarial { get; set; } = [];
		private IList<MotivoEmprestimo>? _motivosEmprestimo { get; set; } = [];

		private string _mensagem;
		private string _classe;
		private bool _loading;

		protected override async Task OnInitializedAsync()
		{
			_resposta.Convenio ??= new();
			_resposta.FaixaIdade ??= new();
			_resposta.FaixaSalarial ??= new();
			_resposta.MotivoEmprestimo ??= new();

			await ListarAsync();
		}

		private async Task ListarAsync()
		{
			_loading = true;

			try
			{
				_convenios = await _convenioService.ListarAsync();
				_faixasIdade = await _faixaIdadeService.ListarAsync();
				_faixasSalarial = await _faixaSalarialService.ListarAsync();
				_motivosEmprestimo = await _motivoEmprestimoService.ListarAsync();
			}
			catch (Exception)
			{
				_mensagem = "Ocorreu um erro ao carregar os itens da página.";
				_classe = "danger";
			}

			_loading = false;
		}

		private async Task SalvarAsync()
		{
			_loading = true;

			if (ValidarFormulario())
			{
				var resposta = await respostaService.EnviarAsync(_resposta);

				if (resposta.Id > 0)
				{
					_mensagem = "Respostas enviadas com sucesso.";
					_classe = "success";

					_resposta = new();
				}
				else
				{
					_mensagem = "Ocorreu um erro ao enviar as respostas. Por favor, tente novamente.";
					_classe = "danger";
				}
			}

			_loading = false;
		}

		private bool ValidarFormulario()
		{
			if(_resposta.Convenio.Id <= 0)
			{
				_mensagem = "Selecione um Convênio.";
				_classe = "warning";
				return false;
			}
			else if (_resposta.FaixaIdade.Id <= 0)
			{
				_mensagem = "Selecione uma Faixa de Idade.";
				_classe = "warning";
				return false;
			}
			else if (_resposta.FaixaSalarial.Id <= 0)
			{
				_mensagem = "Selecione uma Faixa Salarial.";
				_classe = "warning";
				return false;
			}
			else if (_resposta.MotivoEmprestimo.Id <= 0)
			{
				_mensagem = "Selecione um motivo para o empréstimo.";
				_classe = "warning";
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
