using MediatR;

namespace Application.Features.Orders.Command.DeleteOrder
{
    public class DeleteOrderCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
