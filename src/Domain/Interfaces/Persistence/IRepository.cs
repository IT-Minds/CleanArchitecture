namespace MorgenBooster.Domain.Interfaces.Persistence
{
	public interface IRepository<TEntity, TId>
	{
		IQueryable<TEntity> GetAll();
		TEntity GetById(TId id);
		bool Add(TEntity entity);
		bool Update(TEntity entity);
		bool Delete(TId id);
	}
}
