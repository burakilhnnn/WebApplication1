using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ResetCodeRepository : IResetCodeRepository
    {
        private readonly AppDbContext _context;

        public ResetCodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResetPassword> GetResetPasswordByCodeAsync(string resetCode)
        {
            return await _context.ResetPassword
                .AsNoTracking()
                .FirstOrDefaultAsync(rc => rc.ResetCode == resetCode);
        }

        public async Task SaveResetPasswordAsync(ResetPassword resetCodeEntity)
        {
            if (resetCodeEntity == null) return;

            var existing = await _context.ResetPassword
                .FirstOrDefaultAsync(rc => rc.UserId == resetCodeEntity.UserId);

            if (existing != null)
            {
                _context.ResetPassword.Remove(existing);
            }

            await _context.ResetPassword.AddAsync(resetCodeEntity);
            await _context.SaveChangesAsync();
        }
    }
}
