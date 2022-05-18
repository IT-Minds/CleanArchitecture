using MorgenBooster.Application.Queries.Interfaces;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Persistence;

namespace MorgenBooster.Application.Queries
{
	public class GetOrderQuery : IQuery<int, Order>
	{
		private readonly IRepository<Order, int> _repository;
		public GetOrderQuery(IRepository<Order, int> repository)
		{
			_repository = repository;
		}
		public Order Execute(int input)
		{
			try
			{
				var result = _repository.GetById(input);
				return result;
			}
			catch (Exception)
			{
				// LOG SHIT SEND MAIL CRASH EXPLODE IDK
				throw;
			}
		}
	}
}
