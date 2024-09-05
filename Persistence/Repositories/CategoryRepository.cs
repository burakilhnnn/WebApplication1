using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq;

internal class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(Category category, CancellationToken token)
    {
        await dbContext.Categories.AddAsync(category, token);
        await dbContext.SaveChangesAsync(token);
    }

    public void Delete(Category category)
    {
        dbContext.Categories.Remove(category);
        dbContext.SaveChanges();
    }

    public async Task DeleteAsync(Category category, CancellationToken cancellationToken)
    {
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Category>> GetAllCategoriesAsync(int? id, string? name, int? parentId)
    {
        IQueryable<Category> query = dbContext.Categories;

        if (id != null)
        {
            query = query.Where(x => x.Id == id.Value);
        }

        if (parentId != null) 
        {
            query=query.Where(x=>x.ParentId == parentId.Value);
        }
        if (name != null)
        {
            query = query.Where(x => x.Name == name);
        }

        return await query.ToListAsync();

    }

    public async Task<List<Category>> GetAllCategoriesAsync(int? id)
    {
        IQueryable<Category> query = dbContext.Categories;

        if (id != null)
        {
            query = query.Where(x => x.Id == id);
        }
        return await query.ToListAsync();
    }



    public async Task<Category> GetByIdAsync(int id, CancellationToken token)
    {
        return await dbContext.Categories.FindAsync(new object[] { id }, token);
    }

    public async Task UpdateAsync(Category category, CancellationToken token)
    {
        var existingCategory = await dbContext.Categories.FindAsync(new object[] { category.Id }, token);
        if (existingCategory != null)
        {
            dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
            await dbContext.SaveChangesAsync(token);
        }
        else
        {
            throw new KeyNotFoundException("Category not found");
        }
    }
}
