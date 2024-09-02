using Application.Features.Orders.Queries.GetAllOrder;
using Application.Features.Roles.Queries.GetAllRoles;
using MediatR;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllRolesQueryRequest
    {
        public Guid? RoleId { get; set; }

        public GetAllRoleQueryHandler ToQuery()
        {
            return new GetAllRoleQueryHandler(this);
        }
    }
}
