using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges);

        Task<T> GetByIdAsync(Guid id, bool trackChanges);
        T GetById(Guid id, bool trackChanges);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

}

