using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApiHelloCore.Entities;
using ApiHelloCore.Repositories;
using ApiHelloDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiHelloDAL.Repositories
{
    public class GenericRepository<T> (ApiDbContext _context): IGenericRepository<T> where T : BaseEntity, new()
    {
        protected DbSet<T> Table = _context.Set<T>();
        public async Task AddAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
           Table.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
           await Table.Where(x=> x.Id== id).ExecuteDeleteAsync();
        }

        public IQueryable<T> GetAll()
        => Table.AsQueryable();

        public async Task<T?> GetByIdAsync(int id)
        => await Table.FindAsync(id);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        => Table.Where(expression).AsQueryable();

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
    }
}
