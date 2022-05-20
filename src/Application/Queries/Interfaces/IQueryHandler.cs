namespace MorgenBooster.Application.Queries.Interfaces
{
	public interface IQueryHandler<TInput, TOutput>
	{
		TOutput Handle(TInput input);
	}
}
