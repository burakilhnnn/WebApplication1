
using Application.Features.Orders.Queries.GetAllOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id, CancellationToken token);
        Task AddAsync(Order order, CancellationToken token);
        Task UpdateAsync(Order order, CancellationToken token);
        void Delete(Order order); 
        Task DeleteAsync(Order order, CancellationToken cancellationToken); 
        Task<List<Order>> GetAllOrdersAsync(int? id);
            }
}
