using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _dbContext;

    public RoleRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Role role, CancellationToken token)
    {
        await _dbContext.Roles.AddAsync(role, token);
        await _dbContext.SaveChangesAsync(token);
    }

    public void Delete(Role role)
    {
        _dbContext.Roles.Remove(role);
        _dbContext.SaveChanges();
    }

    public async Task DeleteAsync(Role role, CancellationToken cancellationToken)
    {
        _dbContext.Roles.Remove(role);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Role>> GetAllRolesAsync(Guid? id, string? name, string? description)
    {
        IQueryable<Role> query = _dbContext.Roles;

        if (id != null)
        {
            query = query.Where(x => x.Id == id);
        }
        
        if (name != null)
        {
            query = query.Where(x => x.Name == name);
        }        
       
        if (description != null)
        {
            query = query.Where(x => x.Description == description);
        }

        return await query.ToListAsync();
    }


    public async Task<List<Role>> GetAllRolesAsync(Guid? id)
    {
        IQueryable<Role> query = _dbContext.Roles;

        if (id != null)
        {
            query = query.Where(x => x.Id == id);
        }
        return await query.ToListAsync();
    }


        public async Task<Role> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _dbContext.Roles.FindAsync(new object[] { id }, token);
    }

    public async Task UpdateAsync(Role role, CancellationToken token)
    {
        var existingRole = await _dbContext.Roles.FindAsync(new object[] { role.Id }, token);
        if (existingRole != null)
        {
            _dbContext.Entry(existingRole).CurrentValues.SetValues(role);
            await _dbContext.SaveChangesAsync(token);
        }
        else
        {
            throw new KeyNotFoundException("Role not found");
        }
    }
}
