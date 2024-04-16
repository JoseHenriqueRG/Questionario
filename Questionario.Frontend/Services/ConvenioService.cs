using Newtonsoft.Json;
using Questionario.Frontend.Models;

namespace Questionario.Frontend.Services
{
	public class ConvenioService : IQuestionario<Convenio>
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public ConvenioService(
			IHttpClientFactory httpClientFactory,
			IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<IList<Convenio>> ListarAsync()
		{
			List<Convenio> convenios = [];

			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, _configuration["Endpoints:QuestionarioBackend"] + "Convenios");

				var client = _httpClientFactory.CreateClient();

				var response = await client.SendAsync(request);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					convenios = JsonConvert.DeserializeObject<List<Convenio>>(result);
				}
			}
			catch (Exception)
			{
				throw;
			}

			return convenios;
		}
	}
}
