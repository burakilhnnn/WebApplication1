using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

internal class ProductRepository : IProductRepository
{
    private readonly AppDbContext dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(Product product, CancellationToken token)
    {
        await dbContext.Products.AddAsync(product, token);
        await dbContext.SaveChangesAsync(token);
    }

    public void Delete(Product product)
    {
        dbContext.Products.Remove(product);
        dbContext.SaveChanges();
    }

    public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Product>> GetAllProductsAsync(int? id)
    {
       IQueryable<Product>query = dbContext.Products;
        if(id != null)
        {
            query=query.Where(x => x.Id == id);
        }
        
        return await query.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id, CancellationToken token)
    {
        return await dbContext.Products.FindAsync(new object[] { id }, token);
    }

    public async Task UpdateAsync(Product product, CancellationToken token)
    {
        var existingProduct = await dbContext.Products.FindAsync(new object[] { product.Id }, token);
        if (existingProduct != null)
        {
            dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
            await dbContext.SaveChangesAsync(token);
        }
        else
        {
            throw new KeyNotFoundException("Product not found");
        }
    }
}
