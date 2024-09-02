using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(User user, CancellationToken token);
        Task UpdateAsync(User user, CancellationToken token);
        Task DeleteAsync(Guid userId, CancellationToken cancellationToken);
        Task<List<User>> GetAllUsersAsync(Guid? id);
        Task<User> GetByIdAsync(Guid id, CancellationToken token);
        Task<User?> GetUserByFullnameAsync(string fullName); 
        Task<User> GetUserByEmailAsync(string email);
        Task<ResetPassword?> GetResetPasswordByCodeAsync(string resetCode); 
        Task SaveResetPasswordAsync(ResetPassword resetPassword);
       // Task UpdatePasswordAsync(Guid userId, string newPassword);
        Task<bool> ValidateResetCodeAsync(string email, string resetCode);
        Task<User?> GetUserByResetCodeAsync(string resetCode);
        Task<User> GetByIdAsync(Guid userId);
        Task UpdateAsync(User user);
        Task UpdatePasswordAsync(string id, string newPassword);
    }
}
