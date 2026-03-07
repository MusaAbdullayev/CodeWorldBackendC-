using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApiHelloCore.Entities;

namespace ApiHelloCore.Repositories
{
    public interface IGenericRepository<T> where T :BaseEntity, new()
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync (int id);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> expression);
        Task AddAsync (T entity);
        void Delete (T entity);
        Task DeleteAsync (int id);
        Task<int> SaveAsync();

    }
}
