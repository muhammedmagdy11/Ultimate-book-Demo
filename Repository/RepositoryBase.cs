using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Entities.Context;


namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private RepositoryContext _RepositoryContext;

        public RepositoryBase(RepositoryContext RepositoryContext)
        {
            _RepositoryContext = RepositoryContext;
        }
        public void Create(T entity)
        {
            _RepositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _RepositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
          return !trackChanges ? _RepositoryContext.Set<T>().AsNoTracking() : _RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _RepositoryContext.Set<T>().Where(expression).AsNoTracking() : _RepositoryContext.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _RepositoryContext.Set<T>().Update(entity);
        }
    }
}
