using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Roles.Command.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü oluştur
            Role role = new(request.Name, request.Description);

            // Ürünü veritabanına ekle
            await _unitOfWork.GetWriteRepository<Role>().AddAsync(role, cancellationToken);

            // Değişiklikleri kaydet
            await _unitOfWork.SaveAsync();

            // MediatR için dönüş türü
            return Unit.Value;
        }
    }
}
