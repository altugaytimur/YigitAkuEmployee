﻿using System.Linq.Expressions;
using YigitAkuEmployee.Core.Entities.Base;

namespace YigitAkuEmployee.Core.DataAccess.Interfaces;

public interface IAsyncOrderableRepository<TEntity> : IAsyncQueryableRepository<TEntity>, IAsyncRepository where TEntity:BaseEntity
{
	Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> orderby, bool orderDesc = false, bool tracking = true);
	Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TKey>> orderby, bool orderDesc = false, bool tracking = true);

}

