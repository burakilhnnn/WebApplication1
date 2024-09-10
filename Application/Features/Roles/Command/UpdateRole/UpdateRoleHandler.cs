using Application.Common.Interfaces.UnitOfWorks;
using MediatR;
using static Application.Features.Roles.Command.UpdateRole.UpdateRoleHandler;

namespace Application.Features.Roles.Command.UpdateRole
{

    public class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        // private readonly IMapper mapper;

        public UpdateRoleHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var role = await unitOfWork.Roles.GetByIdAsync(request.Id, cancellationToken);

            // Ürünü güncelle
            role.Id = request.Id;
            role.Name = request.Name;
            role.Description = request.Description;


        // Değişiklikleri veritabanına kaydet
        await unitOfWork.CommitAsync();

            return Unit.Value; // MediatR için dönüş türü
        }

        public class UpdateRoleRequest : IRequest<Unit>
        {

            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        }

    }
}




