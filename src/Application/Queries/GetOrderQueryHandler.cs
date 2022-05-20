using MorgenBooster.Application.Queries.Interfaces;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Application.Interfaces.Persistence;

namespace MorgenBooster.Application.Queries
{
	public class GetOrderQueryHandler : IQueryHandler<int, Order>
	{
		private readonly IRepository<Order, int> _repository;
		public GetOrderQueryHandler(IRepository<Order, int> repository)
		{
			_repository = repository;
		}
		public Order Handle(int input)
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
