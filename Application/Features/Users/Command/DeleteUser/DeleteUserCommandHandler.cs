using Application.Features.Users.Command.DeleteUser;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var user = await _unitOfWork.GetReadRepository<User>().GetByIdAsync(request.Id, cancellationToken);


            // Silme işlemi
            _unitOfWork.GetWriteRepository<User>().Delete(user);

            // Değişiklikleri veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
