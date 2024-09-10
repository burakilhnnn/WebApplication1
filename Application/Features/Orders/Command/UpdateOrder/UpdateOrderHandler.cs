using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Application.Features.Orders.Command.UpdateOrder.UpdateOrderHandler;

namespace Application.Features.Orders.Command.UpdateOrder
{

    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateOrderHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var order = await unitOfWork.Orders.GetByIdAsync(request.Id, cancellationToken);

            // Ürünü güncelle
            order.Id = request.Id;

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.CommitAsync();

            return Unit.Value; // MediatR için dönüş türü
        }


        public class UpdateOrderRequest : IRequest<Unit>
        {
            public int Id { get; set; }
            public OrderProduct OrderProduct { get; set; }
            public string USerId { get; set; }
            public DateTime OrderDate { get; set; } = DateTime.UtcNow;
            public DateTime PaymentDate { get; set; }
        }

    }
}




