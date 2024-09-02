using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class,IEntityBase,new()
    {

        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
