using Newtonsoft.Json;
using Questionario.Frontend.Models;
using System.Net.Http;

namespace Questionario.Frontend.Services
{
	public class FaixaSalarialService : IQuestionario<FaixaSalarial>
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public FaixaSalarialService(
			IHttpClientFactory httpClientFactory,
			IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<IList<FaixaSalarial>> ListarAsync()
		{
			List<FaixaSalarial> faixasSalariais = [];

			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, _configuration["Endpoints:QuestionarioBackend"] + "FaixasSalariais");

				var client = _httpClientFactory.CreateClient();

				var response = await client.SendAsync(request);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					faixasSalariais = JsonConvert.DeserializeObject<List<FaixaSalarial>>(result);
				}
			}
			catch (Exception)
			{
				throw;
			}

			return faixasSalariais;
		}
	}
}
