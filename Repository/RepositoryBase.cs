using System;
using System.Linq;
using System.Linq.Expressions;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementPortal.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected readonly  RepositoryContext RepositoryContext;
        protected readonly DbSet<T> DbSet;

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
            this.DbSet = repositoryContext.Set<T>();
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            trackChanges ? this.DbSet : this.DbSet.AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? this.DbSet.Where(expression)
                : this.DbSet.Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            this.DbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            this.DbSet.Remove(entity);
        }
    }
}
