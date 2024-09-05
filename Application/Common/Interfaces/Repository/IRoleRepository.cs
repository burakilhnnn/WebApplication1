using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IRoleRepository
    {
        Task AddAsync(Role role, CancellationToken token);
        Task UpdateAsync(Role role, CancellationToken token);
        void Delete(Role role);

        Task DeleteAsync(Role role, CancellationToken cancellationToken);
        Task<List<Role>> GetAllRolesAsync(Guid? id, string? name, string? description);
        Task<Role> GetByIdAsync(Guid id, CancellationToken token);
    }

}
