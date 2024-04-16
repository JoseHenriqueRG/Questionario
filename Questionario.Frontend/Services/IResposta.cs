using Questionario.Frontend.Models;

namespace Questionario.Frontend.Services
{
	public interface IResposta
	{
		Task<Resposta> EnviarAsync(Resposta resposta);
	}
}
