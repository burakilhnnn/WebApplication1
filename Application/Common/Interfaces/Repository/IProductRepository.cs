
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

        Task DeleteAsync(Product product, CancellationToken cancellationToken); 
        Task<List<Product>> GetAllProductsAsync(int? id, string? title, string? description, decimal? price, int? categoryId, string? stock, decimal? maxPrice, decimal? minPrice);
        Task<List<Product>> GetAllProductsAsync(int? id);
    }
}
