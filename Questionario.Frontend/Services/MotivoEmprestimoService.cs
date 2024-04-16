using Newtonsoft.Json;
using Questionario.Frontend.Models;
using System.Net.Http;

namespace Questionario.Frontend.Services
{
	public class MotivoEmprestimoService : IQuestionario<MotivoEmprestimo>
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public MotivoEmprestimoService(
			IHttpClientFactory httpClientFactory,
			IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<IList<MotivoEmprestimo>> ListarAsync()
		{
			List<MotivoEmprestimo> motivosEmprestimo = [];

			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, _configuration["Endpoints:QuestionarioBackend"] + "MotivosEmprestimo");

				var client = _httpClientFactory.CreateClient();

				var response = await client.SendAsync(request);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					motivosEmprestimo = JsonConvert.DeserializeObject<List<MotivoEmprestimo>>(result);
				}
			}
			catch (Exception)
			{
				throw;
			}

			return motivosEmprestimo;
		}
	}
}
