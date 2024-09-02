using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.CreateOrder
{
    // IRequestHandler<TRequest, TResponse> arayüzünü implement et
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            // Order nesnesini oluştururken Product ve OrderProduct nesnelerini ekleyin
            Order order = new Order
            {
                Products = request.Products, // Product listesini ekleyin
                OrderProduct = request.OrderProduct // OrderProduct nesnesini ekleyin
            };

            await _unitOfWork.GetWriteRepository<Order>().AddAsync(order, cancellationToken);

            // Değişiklikleri kaydet
            await _unitOfWork.SaveAsync();

            // MediatR için boş döndürme
            return Unit.Value;
        }
    }
}
