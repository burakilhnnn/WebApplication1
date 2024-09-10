using Application.Common.Interfaces.Repository;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); } 

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if(!enableTracking) queryable =queryable.AsNoTracking();
            if(include is not null) queryable=include(queryable);
            if(predicate is not null)queryable=queryable.Where(predicate);
            if(orderby is not null)
                return await orderby(queryable).ToListAsync();


            var a = await queryable.ToListAsync();

            return await queryable.ToListAsync();

        }
         public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderby is not null)
                return await orderby(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await queryable.ToListAsync();
        } 
         
        
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if(predicate is not null) Table.Where(predicate);
            return await Table.CountAsync();
        }

        async Task<IList<T>> IReadRepository<T>.GetAsync(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool enableTracking)
        {
            return await Table.ToListAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public Task<IEnumerable<object>> FindAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }


        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }
    }
}
