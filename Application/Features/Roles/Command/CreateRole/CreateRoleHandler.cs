using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Application.Features.Roles.Command.CreateRole.CreateRoleHandler;

namespace Application.Features.Roles.Command.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
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

        public class CreateRoleRequest : IRequest<Unit>
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
