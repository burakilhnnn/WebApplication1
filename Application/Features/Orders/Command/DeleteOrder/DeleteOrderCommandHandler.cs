using Application.Features.Orders.Command.DeleteOrder;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var order = await _unitOfWork.GetReadRepository<Order>().GetByIdAsync(request.Id, cancellationToken);



            // Silme işlemi
            _unitOfWork.GetWriteRepository<Order>().Delete(order);

            // Değişiklikleri veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
