using Application.Features.Orders.Queries.GetAllOrder;
using Application.Features.Users.Queries.GetAllUsers;
using MediatR;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllUsersQueryRequest
    {
        public Guid? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public List<Guid>? Roles { get; set; }

        public GetAllUserQueryHandler ToQuery()
        {
            return new GetAllUserQueryHandler(this);
        }
    }
}
