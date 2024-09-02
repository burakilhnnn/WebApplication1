using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface ICategoryRepository 
    {
        Task<Category> GetByIdAsync(int id, CancellationToken token);
        Task AddAsync(Category category, CancellationToken token);
        Task UpdateAsync(Category category, CancellationToken token);
        void Delete(Category category);

        Task<List<Category>> GetAllCategoriesAsync(int? id);
        Task DeleteAsync(Category category, CancellationToken cancellationToken);
    }
}
