using Application.Common.Interfaces.Repository;
using Application.Interfaces.Repositories;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UnitOfWorks
{
    public interface  IUnitOfWork:IAsyncDisposable
    {

        IReadRepository<T>GetReadRepository<T>()where T : class,IEntityBase,new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync();
        Task<int> CommitAsync();


     
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        IRoleRepository Roles { get; }
        IResetCodeRepository ResetPassword { get; }



        int Save();

    }
}
