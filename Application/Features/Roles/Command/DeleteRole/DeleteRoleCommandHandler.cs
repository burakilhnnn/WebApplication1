using Application.Features.Roles.Command.DeleteRole;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var role = await _unitOfWork.GetReadRepository<Role>().GetByIdAsync(request.Id, cancellationToken);


            // Silme işlemi
            _unitOfWork.GetWriteRepository<Role>().Delete(role);

            // Değişiklikleri veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
