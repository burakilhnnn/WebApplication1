
using Domain.Entities;

namespace Application.Common.Interfaces.Repository
{
    public interface IResetCodeRepository
    {
        Task<ResetPassword> GetResetPasswordByCodeAsync(string resetCode);
        Task SaveResetPasswordAsync(ResetPassword? resetCodeEntity);
    }
}