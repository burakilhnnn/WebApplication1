using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryRequest : IRequest<List<GetOrderByIdQueryResponse>>
    {
        public int Id { get; set; }
    }
}
