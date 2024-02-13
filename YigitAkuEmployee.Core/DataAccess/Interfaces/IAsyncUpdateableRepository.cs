using YigitAkuEmployee.Core.Entities.Base;

namespace YigitAkuEmployee.Core.DataAccess.Interfaces;

public interface IAsyncUpdateableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
{
	Task<TEntity> UpdateAsync(TEntity entity);
}
