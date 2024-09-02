
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken token);
        Task AddAsync(Product product, CancellationToken token);
        Task UpdateAsync(Product product, CancellationToken token);
        void Delete(Product product); 

        Task DeleteAsync(Product product, CancellationToken cancellationToken); // Bu metodun tanımlı olduğundan emin olun
        Task<List<Product>> GetAllProductsAsync(int? id);
    }
}
