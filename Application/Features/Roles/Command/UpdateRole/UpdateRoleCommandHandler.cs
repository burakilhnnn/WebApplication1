using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace Application.Features.Roles.Command.UpdateRole
{

    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        // private readonly IMapper mapper;

        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
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

    }
}




