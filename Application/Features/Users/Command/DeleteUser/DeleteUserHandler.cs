using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;

using static Application.Features.Users.Command.DeleteUser.DeleteUserHandler;

namespace Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var user = await _unitOfWork.GetReadRepository<User>().GetByIdAsync(request.Id, cancellationToken);


            // Silme işlemi
            _unitOfWork.GetWriteRepository<User>().Delete(user);

            // Değişiklikleri veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }

        public class DeleteUserRequest : IRequest<Unit>
        {
            public Guid Id { get; set; }
        }

    }
}
