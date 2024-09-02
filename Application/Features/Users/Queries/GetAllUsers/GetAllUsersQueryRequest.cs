using Application.Features.Orders.Queries.GetAllOrder;
using Application.Features.Users.Queries.GetAllUsers;
using MediatR;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllUsersQueryRequest
    {
        public Guid? UserId { get; set; }

        public GetAllUserQueryHandler ToQuery()
        {
            return new GetAllUserQueryHandler(this);
        }
    }
}
