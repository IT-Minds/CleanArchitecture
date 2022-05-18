namespace MorgenBooster.Application.Queries.Interfaces
{
	public interface IQuery<TInput, TOutput>
	{
		TOutput Execute(TInput input);
	}
}
