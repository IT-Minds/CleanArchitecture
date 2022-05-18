using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Persistence;

namespace MorgenBooster.Persistence.EntityFramework
{
	public class EntityFrameworkOrderRepository : IRepository<Order, int>
	{
		public bool Add(Order entity)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Order> GetAll()
		{
			throw new NotImplementedException();
		}

		public Order GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Update(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}
