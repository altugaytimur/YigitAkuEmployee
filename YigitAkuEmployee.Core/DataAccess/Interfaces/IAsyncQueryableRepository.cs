﻿using System.Linq.Expressions;
using YigitAkuEmployee.Core.Entities.Base;

namespace YigitAkuEmployee.Core.DataAccess.Interfaces;

public interface IAsyncQueryableRepository<TEntity> : IAsyncRepository where TEntity: BaseEntity
{
	Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);

	Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking =true);


}
