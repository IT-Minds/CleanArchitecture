using MorgenBooster.Application.Interfaces.Persistence;
using MorgenBooster.Domain.Entities;

namespace MorgenBooster.Persistence.EntityFramework
{
	public class BaseRepository<T> : IRepository<T, int> where T : BaseEntity
	{
		private readonly ECommerceDbContext _context;

		public BaseRepository(ECommerceDbContext dbContext)
		{
			_context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}
		

		public bool Update(T entity)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}


		public IQueryable<T> GetAll()
		{
			return _context.Set<T>();
		}

		T IRepository<T, int>.GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Add(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
