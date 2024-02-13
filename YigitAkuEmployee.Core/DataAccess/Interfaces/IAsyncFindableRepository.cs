﻿using System.Linq.Expressions;
using YigitAkuEmployee.Core.Entities.Base;

namespace YigitAkuEmployee.Core.DataAccess.Interfaces;

public interface IAsyncFindableRepository<TEntity> : IAsyncQueryableRepository<TEntity>, IAsyncRepository where TEntity : BaseEntity
{
	Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
	Task<TEntity?> GetByIdAsync(Guid id, bool tracking = true);
	Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);
}
