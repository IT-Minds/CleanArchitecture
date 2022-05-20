namespace MorgenBooster.Application.Commands.Interfaces
{
	public interface ICommandHandler<TInput, TOutput>
	{
		TOutput Handle (TInput input);
	}

}
