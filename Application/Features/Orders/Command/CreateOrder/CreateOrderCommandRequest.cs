using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Command.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<Unit>
    {
        public List<Product> Products { get; set; }
        public OrderProduct OrderProduct { get; set; }

    }
}
