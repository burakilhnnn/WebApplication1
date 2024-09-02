using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Order order, CancellationToken token)
        {
            await _dbContext.Orders.AddAsync(order,token);
            await _dbContext.SaveChangesAsync(token);
        }

        public void Delete(Order order)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(Order order, CancellationToken cancellationToken)
        {
            _dbContext?.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Order>> GetAllOrdersAsync(int? id)
        {
            IQueryable<Order> query = _dbContext.Orders;

            if (id != null)
            {
                query = query.Where(x => x.Id == id);
            }

            return await query.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id, CancellationToken token)
        {
            return await _dbContext.Orders.FindAsync(new object[] { id }, token);

        }

        public async Task UpdateAsync(Order order, CancellationToken token)
        {
            var existingRole = await _dbContext.Orders.FindAsync(new object[] { order.Id }, token);
            if (existingRole != null)
            {
                _dbContext.Entry(existingRole).CurrentValues.SetValues(order);
                await _dbContext.SaveChangesAsync(token);
            }
            else
            {
                throw new KeyNotFoundException("Order not found");
            }
        }



        // Diğer metodlar
    }

}