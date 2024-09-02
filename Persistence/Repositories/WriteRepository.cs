using Application.Interfaces.Repositories;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _dbContext;

        public WriteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table => _dbContext.Set<T>();

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await Table.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            Table.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);

        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
