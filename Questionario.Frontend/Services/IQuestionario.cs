namespace Questionario.Frontend.Services
{
	public interface IQuestionario<T> where T : class
	{
		Task<IList<T>> ListarAsync();
	}
}
