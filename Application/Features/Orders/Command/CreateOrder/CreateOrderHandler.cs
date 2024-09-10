using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Application.Features.Orders.Command.CreateOrder.CreateOrderHandler;

namespace Application.Features.Orders.Command.CreateOrder
{
    // IRequestHandler<TRequest, TResponse> arayüzünü implement et
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                OrderProduct = request.OrderProduct, 
                UserId = request.UserId, 
                OrderDate = request.OrderDate, 
                PaymentDate = request.PaymentDate 
            };

            await _unitOfWork.GetWriteRepository<Order>().AddAsync(order, cancellationToken);

            // Değişiklikleri kaydet
            await _unitOfWork.SaveAsync();

            // MediatR için boş döndürme
            return Unit.Value;
        }

        public class CreateOrderRequest : IRequest<Unit>
        {
            public OrderProduct OrderProduct { get; set; }
            public string UserId { get; set; }
            public DateTime OrderDate { get; set; } = DateTime.UtcNow;
            public DateTime PaymentDate { get; set; }
        }

    }
}
