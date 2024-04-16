using Newtonsoft.Json;
using Questionario.Frontend.Models;
using System.Net.Http;

namespace Questionario.Frontend.Services
{
	public class FaixaIdadeService : IQuestionario<FaixaIdade>
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public FaixaIdadeService(
			IHttpClientFactory httpClientFactory,
			IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<IList<FaixaIdade>> ListarAsync()
		{
			List<FaixaIdade> faixaIdades = [];

			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, _configuration["Endpoints:QuestionarioBackend"] + "FaixasIdades");

				var client = _httpClientFactory.CreateClient();

				var response = await client.SendAsync(request);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					faixaIdades = JsonConvert.DeserializeObject<List<FaixaIdade>>(result);
				}
			}
			catch (Exception)
			{
				throw;
			}

			return faixaIdades;
		}
	}
}
