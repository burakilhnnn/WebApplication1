using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;

using static Application.Features.Orders.Command.DeleteOrder.DeleteOrderHandler;

namespace Application.Features.Orders.Command.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var order = await _unitOfWork.GetReadRepository<Order>().GetByIdAsync(request.Id, cancellationToken);



            // Silme işlemi
            _unitOfWork.GetWriteRepository<Order>().Delete(order);

            // Değişiklikleri veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }

        public class DeleteOrderRequest : IRequest<Unit>
        {
            public int Id { get; set; }
        }

    }
}
