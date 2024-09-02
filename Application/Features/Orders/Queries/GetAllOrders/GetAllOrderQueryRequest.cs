using Application.Features.Orders.Queries.GetAllOrder;
using MediatR;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryRequest
    {
        public int Id { get; set; }

        public GetAllOrderQueryHandler ToQuery()
        {
            return new GetAllOrderQueryHandler(this);
        }
    }
}
