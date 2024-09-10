using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(User user, CancellationToken token)
    {
        await dbContext.Users.AddAsync(user, token);
        await dbContext.SaveChangesAsync(token);
    }

    public void Delete(User user)
    {
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<User>> GetAllUsersAsync(Guid? id, string? fullName, string? email, List<Guid>? roles)
    {
        IQueryable<User> query = dbContext.Users;

        if (id != null)
        {
            query = query.Where(x => x.Id == id);
        }

        if (fullName != null)
        {
            query = query.Where(x => x.FullName == fullName);
        }

        if (email != null)
        {
            query = query.Where(x => x.Email == email);
        }
        

        
        if (roles != null)
        {
            query = query.Where(x => x.Roles == roles);
        }

        return await query.ToListAsync();
    }


    public async Task<List<User>> GetAllUsersAsync(Guid? id)
    {
        IQueryable<User> query = dbContext.Users;

        if (id != null)
        {
            query = query.Where(x => x.Id == id);
        }
        return await query.ToListAsync();
    }
    

        public async Task UpdateAsync(User user, CancellationToken token)
    {
        var existingUser = await dbContext.Users.FindAsync(new object[] { user.Id }, token);
        if (existingUser != null)
        {
            dbContext.Entry(existingUser).CurrentValues.SetValues(user);
            await dbContext.SaveChangesAsync(token);
        }
        else
        {
            throw new KeyNotFoundException("User not found");
        }
    }

    public async Task<User?> GetUserByFullnameAsync(string fullName)
    {
        return await dbContext.Users
            .FirstOrDefaultAsync(u => u.FullName == fullName);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<ResetPassword?> GetResetPasswordByCodeAsync(string resetCode)
    {
        return await dbContext.ResetPassword
            .FirstOrDefaultAsync(rp => rp.ResetCode == resetCode);
    }

    public async Task SaveResetPasswordAsync(ResetPassword resetPassword)
    {
        dbContext.ResetPassword.Add(resetPassword);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdatePasswordAsync(Guid userId, string newPassword)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            user.Password = newPassword;
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException("Kullanıcı bulunamadı");
        }
    }

    public async Task<bool> ValidateResetCodeAsync(string email, string resetCode)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return false;
        }

        var resetPassword = await dbContext.ResetPassword
            .FirstOrDefaultAsync(rp => rp.UserId == user.Id && rp.ResetCode == resetCode);

        if (resetPassword == null)
        {
            return false;
        }

        return true;
    }

    public async Task<User?> GetUserByResetCodeAsync(string resetCode)
    {
        var resetPassword = await dbContext.ResetPassword
            .FirstOrDefaultAsync(rp => rp.ResetCode == resetCode);

        if (resetPassword == null)
        {
            return null;
        }

        return await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == resetPassword.UserId);
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FindAsync(new object[] { userId }, cancellationToken);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> GetByIdAsync(Guid userId)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        return user;
    }

    public async Task UpdateAsync(User user)
    {
        var existingUser = await dbContext.Users.FindAsync(user.Id);
        if (existingUser == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        dbContext.Entry(existingUser).CurrentValues.SetValues(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdatePasswordAsync(string email, string newPassword)
    {
        if (!IsValidEmail(email))
        {
            throw new ArgumentException("Geçersiz Email");
        }

        // Kullanıcıyı bul
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            throw new KeyNotFoundException("Kullanıcı bulunamadı");
        }

        // Şifreyi güncelle
        user.Password = newPassword;

        // Kullanıcıyı güncelle
        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync();
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(email);
            return mailAddress.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public async Task<User> GetByIdAsync(Guid id, string password, CancellationToken token)
    {
        var user = await dbContext.Users.FindAsync(new object[] { id }, token);

        if (user != null && user.Password == password)
        {
            return user;
        }

        return null;
    }


}
