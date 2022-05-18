namespace MorgenBooster.Application.Commands.Interfaces
{
	public interface ICommand<TInput, TOutput>
	{
		TOutput Execute (TInput input);
	}

}
