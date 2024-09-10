
using Domain.Entities;

namespace Application.Common.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id, CancellationToken token);
        Task AddAsync(Order order, CancellationToken token);
        Task UpdateAsync(Order order, CancellationToken token);
        void Delete(Order order);
        Task DeleteAsync(Order order, CancellationToken cancellationToken);
        Task<List<Order>> GetAllOrdersAsync(int? id, string? userId, DateTime? orderDate, DateTime? paymentDate);
        Task<List<Order>> GetAllOrdersAsync(int? id);


    }
}
