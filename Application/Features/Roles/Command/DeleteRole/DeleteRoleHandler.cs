using Application.Common.Interfaces.UnitOfWorks;
using Application.Features.Roles.Command.DeleteRole;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Roles.Command.DeleteRole.DeleteRoleHandler;

namespace Application.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var role = await _unitOfWork.GetReadRepository<Role>().GetByIdAsync(request.Id, cancellationToken);


            // Silme işlemi
            _unitOfWork.GetWriteRepository<Role>().Delete(role);

            // Değişiklikleri veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }

        public class DeleteRoleRequest : IRequest<Unit>
        {
            public Guid Id { get; set; }

        }
    }
}
