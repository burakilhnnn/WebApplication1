using Application.Common.Interfaces.Repository;
using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWorks;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public int Save() => dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
      
        private IProductRepository _productRepository;

        public IProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(dbContext);
                }
                return _productRepository;
            }
        }

        private IOrderRepository _orderRepository;

        public IOrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(dbContext);
                }
                return _orderRepository;
            }
        }


        private IUserRepository _userRepository;

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(dbContext);
                }
                return _userRepository;
            }
        }

        private ICategoryRepository _categoryRepository;

        public ICategoryRepository Categories
        {
            get 
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(dbContext);
                }
                return _categoryRepository;
            }
        }

        private IRoleRepository _roleRepository;

        public IRoleRepository Roles
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(dbContext);
                }
                return _roleRepository;
            }
        }

        private IResetCodeRepository _resetCodeRepository;
        public IResetCodeRepository ResetPassword
        {
            get
            {
                if (_resetCodeRepository == null)
                {
                    _resetCodeRepository = new ResetCodeRepository(dbContext);
                }
                return _resetCodeRepository;
            }
        }


        public async Task<int> CommitAsync() => await SaveAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
    }

}
