using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.UpdateOrder
{

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var order = await unitOfWork.Orders.GetByIdAsync(request.Id, cancellationToken);

            // Ürünü güncelle
            order.Id = request.Id;

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.CommitAsync();

            return Unit.Value; // MediatR için dönüş türü
        }

    }
}




