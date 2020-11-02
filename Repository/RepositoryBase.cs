using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementPortal.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class, IEntity
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

        public async Task<T> GetByIdAsync(Guid id, bool trackChanges)
        {
            var address = trackChanges
                ? await this.DbSet.FirstOrDefaultAsync(a => a.Id == id)
                : await this.DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

            return address;
        }

        public T GetById(Guid id, bool trackChanges) 
        {
            var address = trackChanges
                ? this.DbSet.FirstOrDefault(a => a.Id == id)
                : this.DbSet.AsNoTracking().FirstOrDefault(a => a.Id == id);

            return address;
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
