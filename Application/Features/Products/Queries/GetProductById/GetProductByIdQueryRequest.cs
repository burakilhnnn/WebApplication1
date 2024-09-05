using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<List<GetProductByIdQueryResponse>>
    {
        public int Id { get; set; }
    }
    
    
}
