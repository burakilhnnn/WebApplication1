using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryRequest : IRequest<List<GetRoleByIdQueryResponse>>
    {
        public Guid Id { get; set; }
    }
}
