using YigitAkuEmployee.Core.Entities.Base;

namespace YigitAkuEmployee.Core.DataAccess.Interfaces;

public interface IAsyncDeleteableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
{
	Task DeleteAsync(TEntity entity);
	Task DeleteRangeAsync(IEnumerable<TEntity> entities);
}
