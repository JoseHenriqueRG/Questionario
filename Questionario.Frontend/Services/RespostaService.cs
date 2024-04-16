using Newtonsoft.Json;
using Questionario.Frontend.Models;
using System.Text;

namespace Questionario.Frontend.Services
{
	public class RespostaService : IResposta
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public RespostaService(
			IHttpClientFactory httpClientFactory,
			IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<Resposta> EnviarAsync(Resposta resposta)
		{
			Resposta Resposta = new();

			try
			{
				var uri =  _configuration["Endpoints:QuestionarioBackend"] + "Respostas";

				var request = new StringContent(JsonConvert.SerializeObject(resposta), Encoding.UTF8, "application/json");

				var client = _httpClientFactory.CreateClient();

				var response = await client.PostAsync(uri, request);

				var result = await response.Content.ReadAsStringAsync();

				if (response.IsSuccessStatusCode)
				{
					Resposta = JsonConvert.DeserializeObject<Resposta>(result);
				}
			}
			catch (Exception)
			{
				throw;
			}

			return Resposta;
		}
	}
}
